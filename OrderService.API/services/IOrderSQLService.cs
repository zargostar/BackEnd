using OrderService.API.services.models;
using OrderService.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace OrderService.API.services
{
    public interface IOrderSQLService
    {
        Task<long> TotalSale(string userId);
        Task<int> Count(string userId);
        Task <List<OrderDto>> Orders(string userId);
    }
}
