using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Features.Resumes.Commands.ResumeCreate;
using OrderService.Application.Features.Resumes.Queries.GetResumeById;

namespace OrderService.API.Controllers
{
    /// <summary>
    /// ljiojhiu
    /// </summary>
    /// <param name="mediator"></param>
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
   
    public class ResumeController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator mediator = mediator;

    /// <summary>
    /// jyguyg
    /// </summary>
    /// <param name="resume"></param>
    /// <returns></returns>
        [HttpPost]
     
        public async Task<IActionResult> Post(ResumeCreateCommand resume)
        {
            await mediator.Send(resume);
            return NoContent();
        }
        [HttpGet("{userId}")]
        public async Task<ActionResult<ResumeDto>> Get(string userId)
        {
          var resume=await  mediator.Send(new GetResumeByIdQuery(userId));
            return Ok(resume);
        }
    }
}
