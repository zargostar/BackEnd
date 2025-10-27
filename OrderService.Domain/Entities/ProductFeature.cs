using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Entities
{
    public class ProductFeature
    {
        public int ProductId { get; set; }
        public int FeatureId { get; set; }
        public string  Value { get; set; }
    }
}
