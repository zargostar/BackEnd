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

namespace OrderService.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper mapper;

        public UpdateProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            this.mapper = mapper;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var includes = new List<Expression<Func<Product, Object>>>()
            {
                x=>x.ProductSize,
                x=>x.ProductFeatures

            };

           // var test =await _repository.GetAsync(x => x.Id == request.Id, orderBy => orderBy.OrderByDescending(x => x.Id), "ProductSize");
            //var newtest=await _repository.GetByIdAsync(request.Id); 
            IReadOnlyList<Product> productList = await _repository.GetAsync(x => x.Id == request.Id,null,  includes,false);
            var productToUpdate=productList.FirstOrDefault();
             mapper.Map(request, productToUpdate);
            await _repository.UpdateAsync(productToUpdate);
        }
    }
}
