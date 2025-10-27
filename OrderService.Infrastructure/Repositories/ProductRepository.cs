using Microsoft.EntityFrameworkCore;
using OrderService.Application.Contracts;
using OrderService.Domain.Entities;
using OrderService.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepositoryAsync<Product>, IProductRepository
    {
        public ProductRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }

        public async Task DisableProduct(int productId)
        {
            await _dbContext.Products.
                  ExecuteUpdateAsync(p => p.SetProperty(x => x.IsActive, p => !p.IsActive)
                  .SetProperty(x => x.Name, p => p.Name + " new")
                  .SetProperty(p => p.Price, p => p.Price -
                  (p.Price * (0.2))
                 ));
            await _dbContext.Products.Where(p=>p.Price>10000)
                .ExecuteUpdateAsync(c=>c.SetProperty(x=>x.Price, p=>p.Price)
                .SetProperty(p=>p.IsActive,true));
          //  _dbContext.Products.
           await _dbContext.Products.Where(x=>x.Price>1000).ExecuteDeleteAsync();
        }

        public async Task<Product> GetProductSize(int id)
        {
            var res= await _dbContext.Products.Include(x=>x.ProductFeatures)
                .Include(p => p.ProductSize).ThenInclude(p=>p.Size)
                .FirstOrDefaultAsync(x=>x.Id==id);
            return res;
        }
    }
}
