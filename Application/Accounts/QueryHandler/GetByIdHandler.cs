using Application.Accounts.Queries;
using AutoMapper;
using Common.Exceptions;
using Domain.Entities;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Accounts.QueryHandler
{
    public class GetByIdHandler
    {
        private BanHangContext _context;

        public GetByIdHandler(BanHangContext context)
        {
            _context = context;
        }
        public Account? GetById(GetById id)
        {
            Account? account = _context.Accounts.Find(id);
            if (account != null)
            {
                return _context.Accounts.Find(id);
            }
            throw new AppException("Không tồn tại tài khoản này!");
        }
    }
}
