using Microsoft.AspNetCore.Mvc;

namespace OrderService.API.Filters
{
    public class CreditAuthorizeAttribute : TypeFilterAttribute
    {
        public CreditAuthorizeAttribute(int credit)
            : base(typeof(CreditAuthorizeFilter))
        {
            Arguments = new object[] { credit };
        }
    }

}
