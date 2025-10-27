using AutoMapper;
using MediatR;
using OrderService.Application.Contracts;
using OrderServise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Products.Queries.GetProductById
{
    internal class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public GetProductByIdQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Product, bool>> query = null;
            var includes = new List<Expression<Func<Product, Object>>>()
            {
                x=>x.ProductSize,
                x=>x.ProductFeatures,
               
               

            };

            //var product = await productRepository.GetAsync(x=>x.Id==request.Id ,o=>o.OrderByDescending(x=>x.Id), includes, true);
            //var test = product.FirstOrDefault();
            var res = await productRepository.GetProductSize(request.Id);
            var result=mapper.Map<ProductDto>(res);
            return result;
        }
    }
}
