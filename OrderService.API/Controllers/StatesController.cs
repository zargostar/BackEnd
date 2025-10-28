using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Features.States.GetStates;

namespace OrderService.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [ApiExplorerSettings(GroupName = "WebSite")]
    public class StatesController : ControllerBase
    {
        private IMediator mediator;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public StatesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        /// <summary>
        /// 
        /// jhuhuhui
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           var result= await mediator.Send(new GetStatesQuery());
            return Ok(result);
        }
    }
}
