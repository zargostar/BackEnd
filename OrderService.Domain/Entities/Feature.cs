using OrderService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Entities
{
    public class Feature:BaseEntity
    {
      
        public string Name { get; set; }
        public List<ProductFeature> ProductFeatures { get; set; }
    }
}
