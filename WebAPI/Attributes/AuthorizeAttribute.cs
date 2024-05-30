using Application.Users.Dto;
using Common.Constants;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.API.Atributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class AuthorizeAttribute: Attribute, IAuthorizationFilter
    {
        private readonly string[] _permissions;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthorizeFilter(Permissions[] permissions, IHttpContextAccessor httpContextAccessor)
        {
            _permissions = permissions;
            _httpContextAccessor = httpContextAccessor;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
            {
                return;
            }
            // authorization
            if (context.HttpContext.Items[ContextItems.UserId] == null)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }
        }
    }
}
