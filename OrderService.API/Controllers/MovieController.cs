using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Contracts;
using OrderService.Application.Features.Movies.Comands;
using OrderService.Application.Features.Movies.Queries.GetMovieById;
using OrderService.Domain.Entities;

namespace OrderService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "WebSite")]
    [AllowAnonymous]

    public class MovieController : ControllerBase
    {
        private IMediator mediator;
        private readonly IMovirRepository movirRepository;

        public MovieController(IMediator mediator, IMovirRepository movirRepository)
        {
            this.mediator = mediator;
            this.movirRepository = movirRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMovieCommand movie)
        {
            await mediator.Send(movie);
            return NoContent();
        }
    
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetMovieByIdQuery(id);
           var result= await mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("moviestream")]
        public async IAsyncEnumerable<string> StreamMovie()
        {
            await foreach (var item in movirRepository.GetAsyncEnemorableMovie())
            {

                await Task.Delay(3000);
                    yield return item.Title;

                
            }

        }
    }
}
