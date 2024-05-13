using Application.Accounts.Commands;
using Application.Accounts.Dto;
using Application.Authenticates.Queries;
using AutoMapper;
using Common.Exceptions;
using Domain.Entities;
using Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Authorizations;

namespace Application.Accounts.CommandHandlers
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, AccountDto>
    {
        private BanHangContext _context;
        private readonly IMapper _mapper;

        public CreateAccountCommandHandler(BanHangContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<AccountDto> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {

            if (!_context.Accounts.Any(x => x.Name == request.Name))
            {
                Account account = new Account();
                account.Name = request.Name;
                account.Password = request.Password;
                //account = _mapper.Map<Account>(request);
                account.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
                _context.Accounts.Add(account);
                _context.SaveChanges();
                return _mapper.Map<AccountDto>(account);
            }
            else
                throw new AppException("Tên đăng nhập " + request.Name + " đã được sử dụng!");
        }
    }
}
