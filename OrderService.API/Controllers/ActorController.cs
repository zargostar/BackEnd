using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using OrderService.API.ApiServices;
using OrderService.API.services;
using OrderService.Application.Features.Actors.Dto;
using OrderService.Application.Features.Actors.Queries.ActorsList;
using OrderService.Application.Features.Movies.Comands;
using OrderService.Application.Features.Orders.Comands.CreateNewOrder;
using OrderService.Application.Models.utiles;
using OrderService.Domain.Entities;
using OrderService.Infrastructure.Persistance;
using OrderServise.Domain.Entities;
using StackExchange.Redis;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Serialization;
using static MongoDB.Driver.WriteConcern;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace OrderService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [ApiExplorerSettings(GroupName = "AdminPannel")]
  
   
    public partial class ActorController : ControllerBase
    {
        private readonly ILogger<ActorController> _logger;
        private DataBaseContext db;
        private SMSService mSService;
        //ActorsListQuery
        private readonly IMediator mediator;

        public ActorController(IMediator mediator, ILogger<ActorController> logger, SMSService mSService, DataBaseContext db)
        {
            this.mediator = mediator;
            _logger = logger;
            this.mSService = mSService;
            this.db = db;
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
        [HttpPost("AddDictionary")]
        public async Task<IActionResult> AddDictionary([FromBody] ActorModel actor, IOrderSQLService orderSQLService)
        {
            var catCount = db.Products.Select(p => p.CategoryId).Distinct().ToQueryString();
            var catCount0 = db.Products.GroupBy(x => x.CategoryId).Count();
            var totalSale = await orderSQLService.TotalSale("23d29699-bcf2-4324-a3b9-d50a1c745d57");
            var query = db.Actors;               // IQueryable
            Console.WriteLine(query.ToQueryString());  // Show generated SQL
            var orders = await orderSQLService.Orders("23d29699-bcf2-4324-a3b9-d50a1c745d57");

            int totalActors = query.Count();
            // Execute after inspecting SQL
            var res0 = db.Actors.Where(x => x.Location.Latitude > 0).ToQueryString();
            LeftGoinPagination();

            var actorAdd = new Actor()
            {
                MetaData = actor.MetaData,
                Address = actor.Address,
                Name = actor.Name,
                Location = actor.Location,
                Degries = [1, 2, 3]

            };
            await db.Actors.AddAsync(actorAdd);
            await db.SaveChangesAsync();

            LeftJoinSelectMany();
            CategoryProductsOrderItems();

            TotallSale();

            TotalSaleForProducts();

            return NoContent();
        }

        private void LeftGoinPagination()
        {
            var r = db.Orders.SelectMany(o => o.Items.DefaultIfEmpty(),
                (o, i) => new
                {
                    OrderId = o.Id,
                    Customer = o.FullName,
                    Price = i != null ? i.Price : 0
                }

             ).GroupBy(x => new { x.OrderId, x.Customer }).Select(x =>
             new
             {
                 Name = x.Key.Customer,
                 Total = x.Sum(c => c.Price)
             })
             .ToPage(new PaginationDto()).ToQueryString();
            ;
        }

        private void CategoryProductsOrderItems()
        {
            //SELECT[c].[Name] AS[CategoryName], COALESCE(SUM([o].[Count] * [o].[Price]), 0) AS[Totalsale]
            //FROM[ordering].[Categories] AS[c]
            //INNER JOIN[ordering].[Products] AS[p] ON[c].[Id] = [p].[CategoryId]
            //INNER JOIN[ordering].[OrderItems] AS[o] ON[p].[Id] = [o].[ProductId]
            //GROUP BY[c].[Id], [c].[Name]

            var test = db.Categories.SelectMany(c => c.Products, (c, p) => new { c, p })
                .SelectMany(cp => cp.p.OrderItems, (cp, oi) => new
                {
                    CName = cp.c.Name,
                    Price = oi.Price,
                    Count = oi.Count,
                    CateforyId = cp.c.Id,

                }).GroupBy(g => new { g.CateforyId, g.CName }).Select(s => new { CategoryName = s.Key.CName, Totalsale = s.Sum(x => x.Count * x.Price) }).ToQueryString();
        }

        private void LeftJoinSelectMany()
        {
            //SELECT[c].[Name] AS[CategoryName], [c].[Id] AS[CategoryId], 
            //COALESCE(COALESCE(SUM([p].[Price]), 0), 0) AS[TotalPrice],
            //COALESCE(SUM([p].[InStock]), CAST(0 AS bigint)) AS[ToTalInStock], COUNT(CASE
            //    WHEN[p].[Id] IS NOT NULL THEN 1
            //END) AS[TCount]
            //FROM[ordering].[Categories] AS[c]
            //LEFT JOIN[ordering].[Products] AS[p] ON[c].[Id] = [p].[CategoryId]
            //GROUP BY[c].[Id], [c].[Name]


            var result = db.Categories.SelectMany(c => c.Products.DefaultIfEmpty(), (c, p) => new
            {
                Name = c.Name,
                Id = c.Id,
                Price = p.Price,
                InStock = p.InStock,
                ProductId = p.Id

            }).GroupBy(g => new { g.Id, g.Name }).Select(s => new
            {
                CategoryName = s.Key.Name,
                CategoryId = s.Key.Id,
                TotalPrice = s.Sum(x => x.Price) ?? 0,
                ToTalInStock = s.Sum(x => x.InStock),
                TCount = s.Count(x => x.ProductId != null)

            }).ToQueryString();
        }

        private void TotalSaleForProducts()
        {
            var ttt = db.Users.SelectMany(u => u.Orders,
                (u, o) => new { u, o })
                .SelectMany(oi => oi.o.Items, (oo, oi) => new
                {

                    Fullname = oo.u.FirstName,
                    OrderDate = oo.o.CreatedAt,
                    Price = oi.Price,
                    Count = oi.Count,


                }).GroupBy(g => g.Fullname).Select(s => new
                {
                    FullName = s.Key,
                    TSum = s.Sum(x => x.Price * x.Count),
                    TCount = s.Count()
                }).ToQueryString();
        }

        private void TotallSale()
        {
            var ZZ0 = db.Orders.SelectMany(u => u.Items,
             (u, i) =>
              new
              {
                  Id = u.Id,
                  Count = i.Count,
                  Price = i.Price,
                  Day = u.CreatedAt.Value.Day,
                  // OrderDate=u.CreatedAt.Day,

              }
            )
             .GroupBy(x => new { x.Day }).Select(g => new { TCount = g.Count(), TSum = g.Sum(c => c.Count * c.Price), DateOrder = g.Key }).ToQueryString();
        }
    }
}
