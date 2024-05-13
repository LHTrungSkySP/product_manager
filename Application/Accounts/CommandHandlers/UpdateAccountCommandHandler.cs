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
    public class UpdateAccountCommandHandler: IRequestHandler<UpdateAccountCommand, AccountDto>
    {
        private BanHangContext _context;
        private readonly IMapper _mapper;

        public UpdateAccountCommandHandler(BanHangContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AccountDto> Handle(UpdateAccountCommand updateRequest, CancellationToken cancellationToken)
        {
            Account? account = _context.Accounts.Find(updateRequest.Id);
            if (account != null)
            {
                if (_context.Accounts.Any(ac => ac.Name == updateRequest.Name))
                {
                    throw new AppException("Đã tồn tại " + updateRequest.Name + " trong hệ thống!");
                }
                if (!string.IsNullOrEmpty(account.Password))
                {
                    account.PasswordHash = BCrypt.Net.BCrypt.HashPassword(updateRequest.Password);
                    account.Password = updateRequest.Password;
                }
                //_mapper.Map(updateRequest, account);
                _context.Accounts.Update(account);
                _context.SaveChanges();
                return _mapper.Map<AccountDto>(account);
            }
            else
                throw new AppException("Không tồn tại tài khoản này!");
        }
    }
}
