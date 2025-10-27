
using MediatR;
using OrderService.Application.Features.Products.Queries.GetProductById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommand:IRequest
    {
        public int CityId { get; set; }
        public int FactoryId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<ProductSizeDto> ProductSize { get; set; }
        public List<ProductFeatureDto> ProductFeatures { get; set; }
    }
}
