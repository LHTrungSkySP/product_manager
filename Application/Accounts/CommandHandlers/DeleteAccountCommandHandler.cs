using Application.Accounts.Commands;
using Common.Exceptions;
using Domain.Entities;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Accounts.CommandHandlers
{
    public class DeleteAccountCommandHandler
    {
        private BanHangContext _context;

        public DeleteAccountCommandHandler(BanHangContext context)
        {
            _context = context;
        }
        public void Delete(DeleteAccountCommand id)
        {
            Account? account = _context.Accounts.Find(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
            }
            else
                throw new AppException("Không tồn tại tài khoản này!");
        }
    }
}
