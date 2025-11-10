using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSService.Api.ApiService;
using SMSService.Api.ApiService.Dtos;

namespace SMSService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly ActorApiService _actorApiService;

        public ActorController(ActorApiService actorApiService)
        {
            _actorApiService = actorApiService;
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> ActorsList(string lan)
        {
         var data= await  _actorApiService.Actors(lan);
         return Ok(data);
        }
        [HttpGet("[Action]/{id}")]
        public async Task<IActionResult> ActorById(int id, string lan)
        {
            var data = await _actorApiService.Actor(id, lan);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> CreateActor([FromBody] ActorModel actor)
        {
            await _actorApiService.AddActor(actor);
            return NoContent();
        }
    }
}
