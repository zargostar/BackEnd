using OrderService.Application.Models.utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Models.userDtos
{
    public class UserSearchDto:PaginationDto
    {
        public string LastName { set; get; }
    }
}
