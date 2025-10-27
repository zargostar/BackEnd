using MediatR;
using OrderService.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.States.GetStates
{
    public class GetStatesQueryHandler : IRequestHandler<GetStatesQuery, List< StateDto>>
    {
        private readonly IMediator _mediator;   
        private readonly IStatesRepositoy statesRepositoy;

        public GetStatesQueryHandler(IMediator mediator, IStatesRepositoy statesRepositoy)
        {
            _mediator = mediator;
            this.statesRepositoy = statesRepositoy;
        }

        public async Task<List<StateDto>> Handle(GetStatesQuery request, CancellationToken cancellationToken)
        {
            var data = await statesRepositoy.GetAsync(null, null, "Cities");
            var res=data.Select(x=>new StateDto() { Id=x.Id,Name=x.Name,Cities=x.Cities.Select(city=>new CityDto() { Id=city.Id,Name=city.Name}).ToList()}).ToList();
            return res;
        }
    }
}
