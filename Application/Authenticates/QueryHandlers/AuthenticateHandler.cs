using Application.Accounts.Dto;
using Application.Authenticates.Dto;
using Application.Authenticates.Queries;
using AutoMapper;
using Common.Exceptions;
using Infrastructure;
using Utility.Authorizations;

namespace Application.Authenticates.QueryHandlers
{
    public class AuthenticateHandler
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
        public AuthenticateDto Authenticate(Authenticate model)
        {
            var user = _mapper.Map<AccountDto>(_context.Accounts.SingleOrDefault(x => x.AccountName == model.AccountName));
            // validate
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                throw new AppException("Username or password is incorrect");

            // authentication successful
            var response = _mapper.Map<AuthenticateDto>(user);
            response.Token = _jwtUtils.GenerateToken<AccountDto>(user,user.Id);
            return response;
        }
    }
}
