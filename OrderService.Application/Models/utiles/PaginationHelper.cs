using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Models.utiles
{
    public static class PaginationHelper
    {
        public static  IQueryable<T> ToPage<T>(this IQueryable<T> list,PaginationDto paginationDto)
        {
            var result = list.Skip((paginationDto.Page - 1)*(paginationDto.Rows)).Take(paginationDto.Rows).AsQueryable();
            return result;
        }
    }
}
