using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrderService.Application.Contracts.payment;
using OrderService.Application.Exceptions;
using OrderService.Application.Models.userDtos;
using OrderService.Application.Models.utiles;
using OrderService.Domain.Common;
using OrderService.Domain.Entities;
using OrderService.Infrastructure.Persistance;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;

namespace OrderService.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "WebSite")]
    // [Authorize]
    public class UserController : ControllerBase
    {
        private DataBaseContext context;
        private readonly IConfiguration _config;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, IConfiguration config, DataBaseContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _config = config;
            this.context = context;
        }
        // [Authorize(Roles =UserRole.ADMIN)]
        //[Authorize(Policy ="IsAdmin")]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        [AllowAnonymous]
        [HttpGet("GetState")]
        public IActionResult GetState()
        {
           
            var state = context.States.ToList();
           return Ok(state);
        }
        [AllowAnonymous]
        [HttpGet("GetStateList")]
        public IActionResult GetStateList([FromQuery]PaginationDto paginationDto)
        {

            var state = context.States;
          var res=  state.ToPage(paginationDto);
            return Ok(res);
        }
    
        
    
        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Post(CreateUserDto userDto)
        {
          var tt=  PaymentFactory.BankSelector(PaymentType.bankMelli);
            tt.Payment(15000);
            var newUser=_mapper.Map<AppUser>(userDto);
            newUser.Email = userDto.UserName;
            var result =await _userManager.CreateAsync(newUser, userDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(err => err.Description));
            }

            return NoContent();

        }
        [AllowAnonymous]
        [HttpPost("Test")]
        public IActionResult Test([FromBody] CreateUserTestDto userDto)
        {
            //var newUser = _mapper.Map<AppUser>(userDto);
            //var result = await _userManager.CreateAsync(newUser, userDto.Password);
            //if (!result.Succeeded)
            //{
            //    return BadRequest(result.Errors.Select(err => err.Description));
            //}
            return BadRequest("ورود ناموفق");
            //return Ok();

        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto,ILogger<UserController> logger )
        {
            logger.LogInformation("it is a log befor error");
            // throw new NullReferenceException();
            //throw new ClientErrorMessage("selected row is not  valid");
            var user=await _userManager.FindByNameAsync(loginDto.UserName);
            if (user is null)
            {
                return BadRequest("ورود ناموفق");
            }
            var LoginResult =await _signInManager.PasswordSignInAsync(user, loginDto.PassWord,false,false);
            if (LoginResult.Succeeded)
            {
                var token =await CreateTokenRole(user, _config);
                return Ok(token);
            }
            return BadRequest("ورود ناموفق");
        }
        [AllowAnonymous]
        [HttpGet("UserList")]
        public async Task<IActionResult> UserList([FromQuery]PaginationDto userDto ,CancellationToken cancellationToken)

        {
            if (!cancellationToken.IsCancellationRequested)
            {
              
                var userList = _userManager.Users.AsQueryable();
                if (userList.Any())
                {

                    await HttpContext.InsertRowCountHeader<AppUser>(userList);
                    var data =await userList.ToPage(userDto).ToListAsync();
                    var result = _mapper.Map<List<UserDto>>(data);
                    return Ok(result);


                }
                throw new ClientErrorMessage("هیچ رکوردی وجود ندارد");
            }
            return Ok();


        }
        [AllowAnonymous]
        [HttpGet("SearchUserByLastname")]
        public async Task<IActionResult> SearchUserByLastname([FromQuery] UserSearchDto userDto,CancellationToken cancellationToken)
       {
            if (cancellationToken.IsCancellationRequested)
            {
                return Ok();
            }
                var userList = _userManager.Users.AsQueryable();
            var search=userList.Where(user=>user.LastName.Contains(userDto.LastName) );
            if (search.Any())
            {
                await HttpContext.InsertRowCountHeader<AppUser>(userList);
                userList = search.ToPage(userDto);
                var result = _mapper.Map<List<UserDto>>(await userList.ToListAsync());
                return Ok(result);


            }
            throw new ClientErrorMessage("هیچ رکوردی وجود ندارد");

        }
        [Authorize]
       
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(CreateUserDto createuser)
        {
            var user =await _userManager.FindByNameAsync(createuser.UserName);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            await _userManager.ResetPasswordAsync(user, token, createuser.UserName);
            return Ok();
        }
        [HttpPost("MobileAuthentication")]
        public async Task<IActionResult> MobileAuthentication( string phone)
        {
            var user = await _userManager.Users.Where(x => x.PhoneNumber == phone).FirstOrDefaultAsync();
            if(user == null)
            {
                return Ok("code");
            }
            else
            {
              var phoneSet=  await _userManager.SetPhoneNumberAsync(user, phone);
                var code = await _userManager.GenerateChangePhoneNumberTokenAsync(user, phone);
               // var code = await _userManager.GenerateUserTokenAsync(user);
                return Ok(code);

            }
           
        }    [HttpPost("CheckMobile")]
        public async Task<IActionResult> CheckMobile(string phone,string code)
        {
            var user = await _userManager.Users.Where(x => x.PhoneNumber == phone).FirstOrDefaultAsync();
            if(user == null)
            {
                return Ok();
            }
            else
            {
              var res=await  _userManager.VerifyChangePhoneNumberTokenAsync(user,code,phone);
                if (res)
                {
                    return Ok();
                }
                else
                {
                    return Ok();
                }

            }
           
        }
        private async Task<LoginResponseDto> CreateTokenRole(AppUser user,IConfiguration _config)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var test = _config["SecurityKey"];
            var roles = await _userManager.GetRolesAsync(user);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecurityKey"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>()
            {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
             new Claim("hassport", "true", ClaimValueTypes.Boolean),
            
            new Claim("fullName",user.FirstName +" "+ user.LastName),
       
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim("roles", role));
            }
            var expirationDate = DateTime.UtcNow.AddDays(30);
            var token = new JwtSecurityToken(issuer: null, audience: null, claims, null, expirationDate, cred);

            return new LoginResponseDto()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpirationDate = expirationDate
            }
           ;

        }

    }
}
