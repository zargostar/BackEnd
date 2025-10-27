using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.States.GetStates
{
    public class StateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CityDto> Cities { get; set; }
    }
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
