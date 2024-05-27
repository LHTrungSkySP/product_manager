
using Application.Users.Dto;
using AutoMapper;
using Common.Constants;
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
        public async Task Invoke(HttpContext context, IJwtUtils jwtUtils, BanHangContext banHangContext, IMapper mapper)
        {
            string? token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateToken(token);
            if (userId != null)
            {
                var user = await banHangContext.Accounts.FindAsync(userId.Value);
                var userInfor = mapper.Map<UserDto>(user);
                // attach user to context on successful jwt validation
                context.Items[ContextItems.UserId] = userInfor.Id;
                context.Items[ContextItems.Username] = userInfor.Name;
                context.Items[ContextItems.Permissions] = userInfor.Permissions;

            }
            await _next(context);
        }
    }
}
