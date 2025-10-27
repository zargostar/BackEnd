using OrderServise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Contracts
{
    public interface IProductRepository : IBaseRepositoryAsync<Product>
    {
        Task<Product> GetProductSize(int id);
        Task DisableProduct(int productId);
       // Task<Product> GetProductHistory(int id);
    }
}
