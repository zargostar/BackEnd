using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Entities
{
    public class SportStudent
    {
        public SportLevel SportLevel { get; set; }
        public int SportId { get; set; }
        public int StudentId { get; set; }

    }
    public  enum SportLevel:short
    {
        None,
        Amator,
        Intermediate,
        Propesional
    }
}
