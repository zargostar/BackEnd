using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OrderService.API.services.models;
using OrderService.Domain.Entities;
using OrderService.Infrastructure.Persistance;
using System.Data;

namespace OrderService.API.services
{
    public class OrderSQLService : IOrderSQLService
    {
        private readonly DataBaseContext context;

        public OrderSQLService(DataBaseContext context)
        {
            this.context = context;
        }

        public async Task<CategoryDto> Categories(Guid id)
        {
            
            
           // var param = new SqlParameter("@Id", id);
            //var res = await context.Categories.FromSqlRaw("exec CategoriesCount @Id", param).ToListAsync();
            var res = await context.Database.SqlQueryRaw<CategoryDto>("exec CategoryById @Id={0}", id).ToListAsync();
            
            return res.FirstOrDefault();
        }

        public async Task<int> Count(bool isActive=true)
        {
            //await Test1();
            //await Test2();
            var ddd = await context.Users.SelectMany(u => u.Orders, (u, o) => new { u, o })
                .SelectMany(uo => uo.o.Items, (uo, i) => new { uo.u.FirstName,i.Price,i.Count,uo.o.Id,uo.o.Freight})
                .GroupBy(g=>g.FirstName)
                .Select(s=> new 
                {s.Key,
                 Total=s.Sum(x=>x.Count*x.Price),
                 sumFreit=s.Select(x=>new {x.Freight,x.Id}).Distinct().Sum(x=>x.Freight),
                 count = s.Select(x=>x.Id).Distinct().Count()}
                )
                .ToListAsync();
            var ddd00 =  context.Users.SelectMany(u => u.Orders, (u, o) => new { u, o })
             .SelectMany(uo => uo.o.Items, (uo, i) => new { uo.u.FirstName, i.Price, i.Count, uo.o.Id, uo.o.Freight })
             .GroupBy(g => g.FirstName)
             .Select(s => new
             {
                 s.Key,
                 Total = s.Sum(x => x.Count * x.Price),
                 sumFreit = s.Sum(x => x.Freight),
                 count = s.Select(x => x.Id).Distinct().Count()
             }
             )
             .ToQueryString();
            var result = await context.Users
                .Select(u => new
                {
                    u.LastName,
                    u.Id,
                    // Count distinct order IDs (to mimic the distinct count in SQL)
                    Total = u.Orders.Select(o => o.Id).Distinct().Count(),
                    // Sum of Freight, ensuring we are summing from the Orders related to each user
                    FreightSum = u.Orders.Sum(o => o.Freight)
                })
                .ToListAsync();
            var result00 =  context.Users
              .Select(u => new
              {
                  u.LastName,
                  u.Id,
                  // Count distinct order IDs (to mimic the distinct count in SQL)
                  Total = u.Orders.Select(o => o.Id).Distinct().Count(),
                  // Sum of Freight, ensuring we are summing from the Orders related to each user
                  FreightSum = u.Orders.Sum(o => o.Freight)
              })
              .ToQueryString();


            var isactive = new SqlParameter("@IsActive", isActive);
            var t = await context.Database.SqlQueryRaw<int>("exec CategoriyCount @IsActive", isactive).ToListAsync();
            return t.FirstOrDefault();
        }

        private async Task Test2()
        {
            var www = await context.Categories.SelectMany(c => c.Products.Where(p => p.IsActive), (c, p) => new
            {
                c.Id,
                c.Name,
                p.InStock
            }).GroupBy(g => new { g.Name })
              .Select(s => new { s.Key.Name, ActiveTotal = s.Count(), InStackTotal = s.Sum(x => x.InStock) })
            .ToListAsync();
            var www0 = context.Categories.SelectMany(c => c.Products.Where(p => p.IsActive), (c, p) => new
            {
                c.Id,
                c.Name,
                p.InStock
            }).GroupBy(g => new { g.Name })
          .Select(s => new { s.Key.Name, ActiveTotal = s.Count(), InStackTotal = s.Sum(x => x.InStock) })
        .ToQueryString();



            var qqq = await context.Categories.SelectMany(c => c.Products, (c, p) => new { c.Name, p.CreatedAt.Value.Year, p.CategoryId })
                .GroupBy(g => g.Year).Select(s => new { s.Key, TotalCount = s.Count() }).ToListAsync();
            var qqq0 = context.Categories.SelectMany(c => c.Products, (c, p) => new { c.Name, p.CreatedAt.Value.Year, p.CategoryId })
               .GroupBy(g => g.Year).Select(s => new { s.Key, TotalCount = s.Count() }).ToQueryString();
        }

        private async Task Test1()
        {
            var co = await context.Categories.SelectMany(c => c.Products,
                (c, p) => new
                {
                    CateGoryName = c.Name,
                    ProductName = p.Name,
                    p.Id,
                    p.Price,
                    p.InStock
                }).ToListAsync();
            var query = context.Categories.SelectMany(c => c.Products,
               (c, p) => new
               {
                   CateGoryName = c.Name,
                   ProductName = p.Name,
                   p.Id,
                   p.Price,
                   p.InStock
               }).ToQueryString();
        }


        //public async Task<CategoryDto> CategoriesCount(Guid id)
        //{
        //    var param = new SqlParameter("@Id", id);
        //    var res = await context.Database.SqlQueryRaw<CategoryDto>("exec OrdersByUserId @Id", param).FirstOrDefaultAsync();
        //    return res;
        //}




        //public async Task<int> Count(string userId)
        //{
        //    var IdParam = new SqlParameter("@Id", 3);
        //    var CountParam = new SqlParameter("@TotalRow", SqlDbType.Int)
        //    {
        //        Direction = ParameterDirection.Output
        //    };

        //    await context.Database.ExecuteSqlRawAsync("exec Test @Id,@TotalRow output", IdParam, CountParam);
        //    return int.Parse(CountParam.Value.ToString() ?? "0");
        //}

        public async Task<List<OrderDto>> Orders(string userId)
        {
            var param = new SqlParameter("@Id", userId);
           var res=await context.Database.SqlQueryRaw<OrderDto>("exec OrdersByUserId @Id", param).ToListAsync();
            return res ;
        }

        public async Task<long> TotalSale(string userId)
        {

            var res = await context.Database
             .SqlQueryRaw<long>("SELECT dbo.TotalSale(@userId) as value", new SqlParameter("@userId", userId))
             .FirstOrDefaultAsync();

            return res;

        }
        //public async Task<long> CategoriesCount(bool isActive=true)
        //{
        //    var IsActive = new SqlParameter("@IsActive", isActive);
           
        //    var res =await context.Database.SqlQueryRaw<long>("exec CategoriesCount @IsActive", IsActive).FirstOrDefaultAsync();
        //    return res;

        //}

       
    }
}
