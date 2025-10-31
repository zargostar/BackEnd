using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.API.ApiServices;
using OrderService.Application.Features.Actors.Dto;
using OrderService.Application.Features.Actors.Queries.ActorsList;
using System.Diagnostics;
using System.Threading;

namespace OrderService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [ApiExplorerSettings(GroupName = "AdminPannel")]
  
   
    public class ActorController : ControllerBase
    {
        private readonly ILogger<ActorController> _logger;
        private SMSService mSService;
        //ActorsListQuery
        private readonly IMediator mediator;

        public ActorController(IMediator mediator, ILogger<ActorController> logger, SMSService mSService)
        {
            this.mediator = mediator;
            _logger = logger;
            this.mSService = mSService;
        }
        [HttpGet("Actors")]
        public async Task<ActionResult<List<ActorDto>>> Get([FromQuery] ActorsListQuery query, CancellationToken cancellationToken)
        {
           
           
            cancellationToken.ThrowIfCancellationRequested();
            _logger.LogInformation("hello logger");
            _logger.LogError("bad err");
            _logger.LogInformation("information logging");
            var resualt =await mediator.Send(query);
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            
            // var res =await mSService.SendSmsByList(new HashSet<int> { 1, 2, 3 },  cancellationToken);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time parllel task: {stopwatch.ElapsedMilliseconds} ms");
            stopwatch.Start();
            var res0 =await  mSService.SendSMSInLINE(new List<int> { 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3 },  cancellationToken);
        
      
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time : {stopwatch.ElapsedMilliseconds} ms");
            return Ok(resualt);
        }
        [HttpGet("actermessage")]
        public async Task<IActionResult> GetActermessage([FromQuery] ActorsListQuery query,CancellationToken cancellationToken)
        {
           
            var resualt = await mediator.Send(query);
            
            var res = await mSService.SendSmsByWhenAll(new HashSet<int> { 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, });
      
            return Ok(new { Actors=resualt,Message= res});
        }
    }
}
