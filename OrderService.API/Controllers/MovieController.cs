using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Contracts;
using OrderService.Application.Features.Actors.Dto;
using OrderService.Application.Features.Movies.Comands;
using OrderService.Application.Features.Movies.Queries.GetMovieById;
using OrderService.Domain.Entities;
using System.Reflection.Metadata.Ecma335;

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
        private readonly IMapper mapper;

        public MovieController(IMediator mediator, IMovirRepository movirRepository, IMapper mapper)
        {
            this.mediator = mediator;
            this.movirRepository = movirRepository;
            this.mapper = mapper;
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
        public async IAsyncEnumerable<ActorDto> StreamMovie()
        {
            await foreach (var item in movirRepository.GetAsyncEnemorableMovie())
            {

                await Task.Delay(3000);
                    var data=mapper.Map<ActorDto>(item);    
                    yield return data;

                
            }

        }
    }
}
