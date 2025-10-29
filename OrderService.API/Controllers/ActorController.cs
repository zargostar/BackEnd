using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Features.Actors.Dto;
using OrderService.Application.Features.Actors.Queries.ActorsList;

namespace OrderService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [ApiExplorerSettings(GroupName = "AdminPannel")]
  
   
    public class ActorController : ControllerBase
    {
        //ActorsListQuery
        private readonly IMediator mediator;

        public ActorController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("Actors")]
        public async Task<ActionResult<List<ActorDto>>> Get([FromQuery] ActorsListQuery query)
        {
            var resualt =await mediator.Send(query);
            return Ok(resualt);
        }
    }
}
