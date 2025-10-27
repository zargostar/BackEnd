

using Microsoft.AspNetCore.Mvc.Filters;

namespace OrderService.API.Filters
{
    public class NewCatchResource : IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            var data=context.Result;
            throw new NotImplementedException();
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            throw new NotImplementedException();
           
        }
    }
}
