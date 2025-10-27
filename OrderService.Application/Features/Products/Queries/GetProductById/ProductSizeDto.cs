using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Products.Queries.GetProductById
{
    public class ProductSizeDto
    {
        public int Id { get; set; }
       
        public double Weight { get; set; }
       public  string Size {  get; set; }
    }
}
