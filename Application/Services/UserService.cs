using Application.Users.Dto;
using AutoMapper;
using Common.Exceptions;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public interface IUserService
    {
        public UserDto GetPermissionOfAccount(int userId);
    }
    public class UserService : IUserService
    {
        private readonly BanHangContext _context;
        private readonly IMapper _mapper;

        public UserService(BanHangContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public UserDto GetPermissionOfAccount(int userId)
        {
            var account = _context.Accounts
            .Include(a => a.AssignGroup)
                .ThenInclude(ag => ag.GroupPermission)
                .ThenInclude(ass => ass.AssignPermissions)
                .ThenInclude(per => per.Permission).Distinct()
            .FirstOrDefault(a => a.Id == userId);
            if (account == null)
            {
                throw new AppException(ExceptionCode.Notfound, "Không tìm thấy Account");
            }
            return _mapper.Map<UserDto>(account);
        }
        //private readonly IHttpContextAccessor _httpContextAccessor;
        //public UserService(IHttpContextAccessor httpContextAccessor)
        //{
        //    _httpContextAccessor = httpContextAccessor;
        //}
        //public string GetUserName()
        //{
        //    var tam = _httpContextAccessor.HttpContext.User.Identity.Name;
        //    return tam ?? "";
        //}
    }
}
