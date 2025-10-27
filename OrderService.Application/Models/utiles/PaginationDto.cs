using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Models.utiles
{
    public class PaginationDto
    {
        private readonly int maxLength = 50;
        public int Page { get; set; } = 1;
        private int recordes = 10;
        public int Rows
        {
            get
            {
                return recordes;
            }
            set
            {
                recordes = value > 50 ? maxLength : value;
            }
        }
    }
}
