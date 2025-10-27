using OrderService.Domain.Entities;
using OrderService.Infrastructure.Persistance;
using OrderService.Application.Contracts;

namespace OrderService.Infrastructure.Repositories
{
    public class StatesRepository : BaseRepositoryAsync<State>, IStatesRepositoy
    {
        public StatesRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
