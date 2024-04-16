using Application.Accounts.Commands;
using Application.Accounts.Dto;
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

namespace Application.Accounts.CommandHandlers
{
    public class DeleteAccountCommandHandler: IRequestHandler<DeleteAccountCommand, AccountDto>
    {
        private BanHangContext _context;
        private IMapper _mapper;

        public DeleteAccountCommandHandler(BanHangContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<AccountDto> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            Account? account = _context.Accounts.Find(request.Id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                return _mapper.Map<AccountDto>(account);
            }
            else
                throw new AppException("Không tồn tại tài khoản này!");
        }
    }
}
