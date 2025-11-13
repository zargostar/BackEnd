using OrderService.Domain.Common;
using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServise.Domain.Entities
{
     public class Suplier:BaseEntity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public List<Product> Products { get; set; }
    }
}
