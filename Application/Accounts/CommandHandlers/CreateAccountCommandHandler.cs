using Application.Accounts.Commands;
using Application.Accounts.Dto;
using AutoMapper;
using Common.Exceptions;
using Domain.Entities;
using Infrastructure;
using MediatR;
using Microsoft.Identity.Client;

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
            if (_context.Accounts.Any(ele => ele.Name == request.Name))
            {
                throw new AppException(
                    ExceptionCode.Duplicate,
                    "Đã tồn tại Account " + request.Name,
                                        new[] {
                        new ErrorDetail(
                            nameof(request.Name),
                            request.Name)
                    }
                    );
            }
            Account account = new Account();
            account.Name = request.Name;
            account.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            account.AssignGroup = request.groupPermissionId.Select(t => new AssignGroup()
            {
                AccountId = account.Id,
                GroupPermissionId = t
            }).ToList();
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return _mapper.Map<AccountDto>(account);
        }
    }
}
