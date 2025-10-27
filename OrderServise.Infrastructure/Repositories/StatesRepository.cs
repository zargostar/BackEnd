using OrderServise.Domain.Entities;
using OrderServise.Infrastructure.Persistance;
using OrderService.Application.Contracts;

namespace OrderServise.Infrastructure.Repositories
{
    public class StatesRepository : BaseRepositoryAsync<State>, IStatesRepositoy
    {
        public StatesRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
