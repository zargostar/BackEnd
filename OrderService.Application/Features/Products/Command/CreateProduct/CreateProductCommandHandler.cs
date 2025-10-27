using AutoMapper;
using MediatR;
using OrderService.Application.Contracts;
using OrderService.Application.Exceptions;
using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Products.Command.CreateProduct
{

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
          
            var product = mapper.Map<Product>(request);
            await productRepository.AddAsync(product);


        }
    }
}
