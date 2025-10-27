using AutoMapper;
using MediatR;

using OrderService.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Sizes.Queries.GetSizes
{
    public class GetSizesQueryHandler : IRequestHandler<GetSizesQuery, List<SizeDto>>
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IMapper  mapper;

        public GetSizesQueryHandler(ISizeRepository sizeRepository, IMapper mapper)
        {
            _sizeRepository = sizeRepository;
            this.mapper = mapper;
        }

        public async Task<List<SizeDto>> Handle(GetSizesQuery request, CancellationToken cancellationToken)
        {
            var sizes = _sizeRepository.GetAllQueryAble();
            var result=mapper.Map<List<SizeDto>>( sizes);
            return result;
        }
    }
}
