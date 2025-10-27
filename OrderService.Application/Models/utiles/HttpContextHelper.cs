using Microsoft.AspNetCore.Http;

using MongoDB.Bson.Serialization.Conventions;
using OrderService.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Models.utiles
{
    public static  class HttpContextHelper
    {
        public static async Task InsertRowCountHeader<T>(this HttpContext httpContext,IQueryable<T> list) {
            if (list == null)
            {
                throw new ClientErrorMessage("لیست ارسالی خالی است");
            }
            int count= list.Count();
            httpContext.Response.Headers.Add("rowcount",count.ToString());
        }
    }
}
