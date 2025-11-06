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

        public async Task<int> Count(string userId)
        {
            var IdParam = new SqlParameter("@Id", 3);
            var CountParam = new SqlParameter("@TotalRow", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            await context.Database.ExecuteSqlRawAsync("exec Test @Id,@TotalRow output", IdParam, CountParam);
            return int.Parse(CountParam.Value.ToString() ?? "0");
        }

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

       
    }
}
