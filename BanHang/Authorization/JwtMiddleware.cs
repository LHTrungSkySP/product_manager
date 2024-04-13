using BanHang.Services;

namespace BanHang.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IAccountService accountService, IJwtUtils jwtUtils)
        {
            string? token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = accountService.GetById(userId.Value);
            }
            await _next(context);
        }
    }
}
