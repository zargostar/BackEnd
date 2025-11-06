using OrderService.Domain.Common;
using OrderServise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Entities
{
    public class Product: BaseEntity
    {
       
        public int? Price { get; set; }
        public long InStock {get; set; } 
        public List<OrderItem> OrderItems { get; set; }
        public Guid? CategoryId { get; set; }
        public string Name { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public List<ProductSize> ProductSize { get; set;}
        public List<ProductFeature> ProductFeatures { get; set; }
        
        //public ProductDetail? ProductDetails { get; set; }
       


        public bool IsActive { get; set; }
    }
}
