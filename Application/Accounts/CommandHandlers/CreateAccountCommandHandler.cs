using Application.Accounts.Commands;
using Application.Accounts.Dto;
using Application.Accounts.Commands;
using Application.Accounts.Dto;
using AutoMapper;
using Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Exceptions;
using Domain.Entities;

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
            Account account = _context.Accounts.Find(request.Name) ?? throw new AppException(
                    ExceptionCode.Duplicate,
                    "Đã tồn tại Account " + request.Name,
                                        new[] {
                        new ErrorDetail(
                            nameof(request.Name),
                            request.Name)
                    }
                    );
            account.Name = request.Name;
            account.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return _mapper.Map<AccountDto>(account);
        }
    }
}
