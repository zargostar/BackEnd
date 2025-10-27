using Microsoft.AspNetCore.Mvc.Filters;

namespace OrderService.API.Filters
{
    public class ResourceCatch :Attribute, IActionFilter
    {
        
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var path=context.HttpContext.Request.Path; 
            var data = context.Result;
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var path = context.HttpContext.Request.Path;
            var data = context.Result;
           
        }
    }
}
