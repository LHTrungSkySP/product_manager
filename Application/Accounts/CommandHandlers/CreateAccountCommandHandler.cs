using Application.Accounts.Commands;
using Application.Authenticates.Queries;
using AutoMapper;
using Common.Exceptions;
using Domain.Entities;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Authorizations;

namespace Application.Accounts.CommandHandlers
{
    public class CreateAccountCommandHandler
    {
        private BanHangContext _context;
        private readonly IMapper _mapper;

        public CreateAccountCommandHandler(BanHangContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Register(CreateAccountCommand registerRequest)
        {

            if (!_context.Accounts.Any(x => x.AccountName == registerRequest.AccountName))
            {
                Account account = new Account();
                account = _mapper.Map<Account>(registerRequest);
                account.PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password);
                _context.Accounts.Add(account);
                _context.SaveChanges();
            }
            else
                throw new AppException("Tên đăng nhập " + registerRequest.AccountName + " đã được sử dụng!");
        }
    }
}
