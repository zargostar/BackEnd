using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Features.Sizes.Queries.GetSizes;

namespace OrderService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly IMediator mediator;

        public SizeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<List<SizeDto>> Get()
        {
         var data=await mediator.Send(new GetSizesQuery());
            return data;
        }
    }
}
