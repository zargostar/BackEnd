using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServise.Domain.Entities
{
    public class TAddress
    {
        public AddressDetail Home { get; set; }
        public AddressDetail Office { get; set; }

       
    }
}
