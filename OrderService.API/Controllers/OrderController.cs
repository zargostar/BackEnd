using AutoMapper;
using Azure.Core;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderService.Application.Features.Orders.Comands.CreateNewOrder;
using OrderService.Application.Features.Orders.Comands.DeleteOrder;
using OrderService.Domain.Entities;
using OrderService.Infrastructure.Persistance;

namespace OrderService.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "WebSite")]

    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly DataBaseContext dbContext;



        public OrderController(IMediator mediator, DataBaseContext dbContext) 
        {
            _mediator = mediator;
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderItemCommand ordr)
        {


            // await _mediator.Send(orderItem);
           // var client = new BackgroundJobClient();
            if (ordr is not null)
            {
                await _mediator.Send(ordr);
                //  client.Enqueue<OrderItemCommand>((ordr) => hangStart(ordr));
             //  BackgroundJob.Enqueue(() => hangStart(ordr));
               // await _mediator.Send(ordr);
            }
          
          //  BackgroundJob.Enqueue();
          return NoContent();   
        }
        private async Task hangStart(OrderItemCommand orderItem)
        {
            //var client = new BackgroundJobClient();
            await _mediator.Send(orderItem);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var orderToDelete = new DeleteOrderCommand(id);

            await _mediator.Send(orderToDelete);
            return NoContent();
        }
        [HttpGet("testEf/{id}")]
        public async Task<ActionResult<bool>> TestEf(int id)
        {
            //var test = dbContext.Orders.Include(x => x.Items).ToList();
            //var test0 = dbContext.Orders.Include(x => x.Items.Where(x=>  x.OrderId==21 )).ToQueryString(); left join
            var data = (from o in dbContext.Orders 
                        join oi in dbContext.OrderItems on o.Id equals oi.OrderId
                        where oi.Price>1000
                        group  oi  by new { oi.OrderId, o.FullName } into g
                        where g.Sum(x=>x.Price)>15000
                        select new {Id=g.Key
                           ,Name=g.Key.FullName,
                           Number= g.Count(),
                           Items=g.Sum(x=>x.Count),
                           Total= g.Sum(x=>x.Count*x.Price) }).ToQueryString();
            var m = await dbContext.Employees.Include(x => x.Manager).FirstOrDefaultAsync(x=>x.Id==1);

            var re = await dbContext.OrderItems.AnyAsync(x => x.Id == id);
            return Ok(re);        }
    }
}
