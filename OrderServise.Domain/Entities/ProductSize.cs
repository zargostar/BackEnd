using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServise.Domain.Entities
{
    public class ProductSize
    {
       
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public double Weight { get; set; }
       public Size Size { get; set; }
    }
}
