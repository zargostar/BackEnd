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
    public class SizeRepository : BaseRepositoryAsync<Size>, ISizeRepository
    {
        public SizeRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
