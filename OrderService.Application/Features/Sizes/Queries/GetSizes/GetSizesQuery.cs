using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Sizes.Queries.GetSizes
{
    public class GetSizesQuery:IRequest<List<SizeDto>>
    {
    }
}
