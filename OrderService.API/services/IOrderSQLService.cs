using OrderService.API.services.models;
using OrderService.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace OrderService.API.services
{
    public record CategoryDto(string Name);
    public interface IOrderSQLService
    {
        Task<long> TotalSale(string userId);
        Task<int> Count(bool isActive=true);
        Task <List<OrderDto>> Orders(string userId);
        Task<CategoryDto> Categories(Guid id);
    }
}
