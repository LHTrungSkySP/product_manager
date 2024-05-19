
using Infrastructure;
using Utility.Authorizations;

namespace Web.API.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IJwtUtils jwtUtils, BanHangContext banHangContext)
        {
            string? token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = banHangContext.Accounts.Find(userId.Value);
            }
            await _next(context);
        }
    }
}
