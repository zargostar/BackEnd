﻿using OrderService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Entities
{
    public class Employee:BaseEntity
    {
        public string FullName { get; set; }
        public int Position { get; set; }
        
        public List<Employee> Employees { get; set; }
        public Employee Manager { get; set; }
        public int? ManagerId { get; set; }

    }
}
