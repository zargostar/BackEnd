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
    public class GenreRepository : BaseRepositoryAsync<Genre>, IGenreRepository
    {
        public GenreRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
