using Amazon.Runtime.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OrderService.Application.Features.Products.Queries.GetProductById;
namespace OrderService.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommand : MediatR.IRequest
    {
        public int CityId { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public int FactoryId { get; set; }
        public List<ProductSizeDto> ProductSizes { get; set; }
        public List<ProductFeatureDto> ProductFeatures { get; set; }

    }
}
