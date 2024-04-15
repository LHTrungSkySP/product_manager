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
    public class UpdateAccountCommandHandler
    {
        private BanHangContext _context;
        private readonly IMapper _mapper;

        public UpdateAccountCommandHandler(BanHangContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Update(int id, UpdateAccountCommand updateRequest)
        {
            Account? account = _context.Accounts.Find(id);
            if (account != null)
            {
                if (_context.Accounts.Any(ac => ac.AccountName == updateRequest.AccountName))
                {
                    throw new AppException("Đã tồn tại " + updateRequest.AccountName + " trong hệ thống!");
                }
                if (!string.IsNullOrEmpty(account.Password))
                {
                    account.PasswordHash = BCrypt.Net.BCrypt.HashPassword(updateRequest.Password);
                }
                _mapper.Map(updateRequest, account);
                _context.Accounts.Update(account);
                _context.SaveChanges();
            }
            else
                throw new AppException("Không tồn tại tài khoản này!");
        }
    }
}
