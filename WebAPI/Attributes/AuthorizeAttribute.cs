using Common.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.API.Atributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute(params Permissions[] claim) : base(typeof(AuthorizeFilter))
        {
            Arguments = new object[] { claim };
        }
    }
    public class AuthorizeFilter :  IAuthorizationFilter
    {

        readonly Permissions[] _permissions;
        public AuthorizeFilter(params Permissions[] claims)
        {
            _permissions = claims;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var tam = _permissions;
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
            {
                return;
            }
            // authorization
            int? userId = (int?)context.HttpContext.Items[ContextItems.UserId];
            if (context.HttpContext.Items[ContextItems.UserId] == null)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }

            //Lấy thông tin người dùng
            //Permissions[] permissions =  context.HttpContext.Items[ContextItems.Permissions]; 
        }
    }
}
