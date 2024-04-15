using Application.Accounts.QueryHandler;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Utility.Authorizations;

namespace WebAPI.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IJwtUtils jwtUtils)
        {
            string? token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateToken(token);
            if (userId != null)
            {
                BanHangContext hangContext = new BanHangContext();
                // attach user to context on successful jwt validation
                context.Items["User"] = hangContext.Accounts.Find(userId.Value);
            }
            await _next(context);
        }
    }
}
