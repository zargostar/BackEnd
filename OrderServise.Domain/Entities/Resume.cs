using OrderServise.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServise.Domain.Entities
{
    public class Resume:BaseEntity
    {
       
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public List<Skill> Skills { get; set; }
    }
    public class Skill:BaseEntity
    {
       
        public string Title { get; set; }
        public string Level { get; set; }
    }
}
