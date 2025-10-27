using Microsoft.EntityFrameworkCore;
using OrderService.Application.Contracts;
using OrderServise.Domain.Entities;
using OrderServise.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServise.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepositoryAsync<Order>, IOrderRepository
    {
        public OrderRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<Order> GetOrderForUser(string UserId)
        {
            var data= await _dbContext.Orders.Include(x=>x.Items).FirstOrDefaultAsync(order=>order.UserId == UserId);
            ////var t = await _dbContext.Products.Include(x=>x.orderi)
            //var list = await _dbContext.Products.Include(x => x.OrderItems).Select(x => new { Name = x.Name, Count =  x.OrderItems.Count()  }).ToListAsync();
            //var list00 =  _dbContext.Products.Include(x => x.OrderItems).Select(x => new { Name = x.Name, Count = x.OrderItems.Count() }).ToQueryString();
            ////var t = await _dbContext.OrderItems.GroupBy(x => x).ToListAsync();
            //var count =_dbContext.OrderItems.Count();
            //var count0 = _dbContext.OrderItems.GroupBy(x => x.ProductId).Select(x => new { PId = x.Key, Number = x.Count() });
            //var count00 = _dbContext.OrderItems.GroupBy(x => x.ProductId).Select(x => new { PId = x.Key, Number = x.Count() }).ToQueryString();
            var sele = _dbContext.OrderItems.GroupBy(x => x.ProductId).Select(x => new { pid = x.Key, avg = x.Sum(x => x.Price * x.Count) }).ToList();
            var sele0 = _dbContext.OrderItems.GroupBy(x => x.ProductId).Select(x => new { pid = x.Key, avg = x.Sum(x => x.Price*x.Count) }).ToQueryString();
            // var count0 = _dbContext.OrderItems.Count;
          //  var q = _dbContext.OrderItems.Sum(x=>x.Price*x.Count);
            var list0 =  _dbContext.Products.Include(x => x.OrderItems).ToQueryString();
            return data;
        }

        public async Task<Order> GetOrderHistoryAsync(int Id)
        {
           // _dbContext.Orders.TemporalAsOf=>return history of special Time
            //we can recicevd history of changes in data base
         var res= await _dbContext.Orders.TemporalAll().Where(p=>p.Id == Id)
                .OrderBy(p => EF.Property<DateTime>(p, "PeriodEnd")).Select(p=>new
                {
                    start=EF.Property<DateTime>(p,"PeriodEnd")
                }).ToListAsync();
            return null;
        }
        
        //public Task GetOrderByUserId(string UserId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
