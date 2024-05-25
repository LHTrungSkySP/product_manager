using Application.Accounts.Dto;
using Application.Authenticates.Dto;
using Application.Authenticates.Queries;
using AutoMapper;
using Common.Exceptions;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Utility.Authorizations;

namespace Application.Authenticates.QueryHandlers
{
    public class AuthenticateHandler : IRequestHandler<Authenticate, AuthenticateDto>
    {
        private BanHangContext _context;
        private readonly IMapper _mapper;
        private readonly IJwtUtils _jwtUtils;
        public AuthenticateHandler(BanHangContext context, IMapper mapper, IJwtUtils jwtUtils)
        {
            _context = context;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
        }

        public async Task<AuthenticateDto> Handle(Authenticate request, CancellationToken cancellationToken)
        {
            var user = await _context.Accounts.Include(a => a.AssignGroup)
                    .ThenInclude(ag => ag.GroupPermission).ThenInclude(p => p.AssignPermissions).ThenInclude(p => p.Permission).FirstOrDefaultAsync(a => a.Name == request.Name, cancellationToken);
            if (user == null)
            {
                throw new AppException(ExceptionCode.Notfound, "Không tìm thấy Account " + request.Name);
            }

            // validate
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new AppException(ExceptionCode.Invalidate, "Username or password is incorrect");

            // authentication successful
            var response = _mapper.Map<AuthenticateDto>(user);
            response.Token = _jwtUtils.GenerateToken<int>(response.Id);
            return response;
        }
    }
}