using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using OrderService.Application.Contracts;
using OrderService.Domain.Entities;
using System.Security.Claims;

namespace OrderService.API.services
{
    public interface IUserValidation
    {
       
        Task Excecut(TokenValidatedContext context);
       
    }
    public class UserValidation : IUserValidation
    {
        private UserManager<AppUser> userManager;
      

        public UserValidation(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
            
        }

        public async Task Excecut(TokenValidatedContext context)
        {
            var claimsIdentity = context?.Principal?.Identity as ClaimsIdentity;
            if (claimsIdentity?.Claims == null || !claimsIdentity.Claims.Any())
            {
                context?.Fail("claim not foundla");
                return;
            }
          var userId = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await userManager.FindByIdAsync(userId);
            if (!user.IsActive)
            {
                context?.Fail("claim not foundla");
                return;
            }
           
        }

        

       
    }
}
