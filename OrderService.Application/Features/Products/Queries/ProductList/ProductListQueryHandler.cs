using Amazon.Runtime.Internal.Util;
using AutoMapper;
using Hangfire;
using MediatR;

using Microsoft.Extensions.Logging;
using OrderService.Application.Contracts;
using OrderService.Application.helper;
using OrderService.Application.Models.utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Products.Queries.ProductList
{
    public class ProductListQueryHandler : IRequestHandler<ProductListQuery, List<ProductListDto>>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        private readonly ILogger<ProductListQueryHandler> logger;

        public ProductListQueryHandler(IProductRepository productRepository, IMapper mapper, ILogger<ProductListQueryHandler> logger)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<List<ProductListDto>> Handle(ProductListQuery request, CancellationToken cancellationToken)
        {
            //RecurringJob.AddOrUpdate("test recurring",
            //  () => logger.LogInformation("tesrtjgguy jyguyg"),Cron.Minutely);
            var list1 = productRepository.GetAllQueryAble().OrderByDescending(x=>x.Id);
           
            var list = list1.ToPage(new PaginationDto() { Page = request.Page,Rows=request.PageSize });
            var res= list;
            var result=mapper.Map<List<ProductListDto>>(res);
            return result;
        }
    }
}
