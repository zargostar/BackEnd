using OrderService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Entities
{
    public class State:BaseEntity
    {
     
        public string Name { get; set; }
        public List<State> Cities { get; set; }
        public int? StateId { get; set; }
       
    }
}
