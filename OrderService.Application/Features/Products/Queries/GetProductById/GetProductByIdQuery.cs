using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
        public bool IsActive { get; set; }
        public int Id { get;private set; }
    }
}
