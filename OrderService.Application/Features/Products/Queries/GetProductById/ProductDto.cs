using OrderServise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Products.Queries.GetProductById
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int FactoryId { get; set; }
        public List<ProductSizeDto> ProductSizes { get; set; }
        public List<ProductFeatureDto> ProductFeatures { get; set; }
    }
}
