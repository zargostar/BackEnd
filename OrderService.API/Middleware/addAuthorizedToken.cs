using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace OrderService.API.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class addAuthorizedToken
    {
        private readonly RequestDelegate _next;

        public addAuthorizedToken(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class addAuthorizedTokenExtensions
    {
        public static IApplicationBuilder UseaddAuthorizedToken(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<addAuthorizedToken>();
        }
    }
}
