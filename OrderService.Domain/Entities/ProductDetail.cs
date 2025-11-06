using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServise.Domain.Entities
{
    public class ProductDetail
    {
        public string Color { get; set; }
        public string Size { get; set; }
        public Dictionary<string, string> MetaData { get; set; }
    }
}
