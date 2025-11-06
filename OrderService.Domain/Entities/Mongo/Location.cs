using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServise.Domain.Entities.Mongo
{
    public class Location
    {
        public decimal Lat {  get; set; } 
        public decimal Long { get; set; }
    }
}
