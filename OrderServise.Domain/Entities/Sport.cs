using OrderServise.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServise.Domain.Entities
{
    public class Sport:BaseEntity
    {
        public string  Name  { get; set; }
        public bool IsActive { get; set; }
        public List<SportStudent> SportStudents { get; set; }
    }
}
