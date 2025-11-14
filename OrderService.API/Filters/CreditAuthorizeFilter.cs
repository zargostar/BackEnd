using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OrderService.Application.Contracts;
using OrderService.Domain.Entities;

namespace OrderService.API.Filters
{
    public class CreditAuthorizeFilter : IAsyncAuthorizationFilter
    {
        private readonly UserManager<AppUser> userManager;
        private readonly int Credit;
        private readonly ICurrentUser currentUser;


        public CreditAuthorizeFilter(UserManager<AppUser> userManager, int credit, ICurrentUser currentUser)
        {
            this.userManager = userManager;
            Credit = credit;
            this.currentUser = currentUser;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var userId=currentUser.UserId;
            var yy = context.HttpContext.User.FindFirst("hassport").Value;
            var user = await userManager.FindByIdAsync(userId);
            if (user.Credit < Credit)
            {
                context.Result = new ForbidResult();
            }
           
        }
    }
}
