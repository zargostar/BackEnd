using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace OrderService.API.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomExeption
    {
        private readonly RequestDelegate _next;

        public CustomExeption(RequestDelegate next)
        {
         
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                 await _next(httpContext);

            }
            catch(Exception ex)
            {
                throw;
            }
            
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomExeptionExtensions
    {
        public static IApplicationBuilder UseCustomExeption(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExeption>();
        }
    }
}
