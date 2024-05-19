using Application.Accounts.Commands;
using Application.Accounts.Dto;
using AutoMapper;
using Azure.Core;
using Common.Exceptions;
using Domain.Entities;
using Infrastructure;
using MediatR;

namespace Application.Accounts.CommandHandlers
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, AccountDto>
    {
        private BanHangContext _context;
        private readonly IMapper _mapper;

        public DeleteAccountCommandHandler(BanHangContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<AccountDto> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            Account account = _context.Accounts.Find(request.Id) ?? throw new AppException(
                ExceptionCode.Notfound,
                "Không tìm thấy Account " + request.Id,
                new[] {
                    new ErrorDetail(nameof(request.Id),request.Id)
                }
            );
            _context.Accounts.Remove(account);
            _context.SaveChanges();
            return _mapper.Map<AccountDto>(account);
        }
    }
}
