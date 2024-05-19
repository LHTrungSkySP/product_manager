using Application.Accounts.Commands;
using Application.Accounts.Dto;
using AutoMapper;
using Common.Exceptions;
using Domain.Entities;
using Infrastructure;
using MediatR;

namespace Application.Accounts.CommandHandlers
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, AccountDto>
    {
        private BanHangContext _context;
        private readonly IMapper _mapper;

        public UpdateAccountCommandHandler(BanHangContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<AccountDto> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            Account account = _context.Accounts.Find(request.Id) ?? throw new AppException(
                    ExceptionCode.Notfound,
                    "Không tìm thấy Account " + request.Name,
                                        new[] {
                        new ErrorDetail(
                            nameof(request.Name),
                            request.Name)
                    }
                    );
            if(BCrypt.Net.BCrypt.Verify(request.PasswordOld, account.PasswordHash))
            {
                account.Name = request.Name;
                account.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.PasswordNew);
                _context.Accounts.Update(account);
                _context.SaveChanges();
                return _mapper.Map<AccountDto>(account);
            }
            else
            {
                throw new AppException(
                    ExceptionCode.Invalidate,
                    "Mật khẩu cũ không đúng",
                                        new[] {
                        new ErrorDetail(
                            nameof(request.Name),
                            request.Name)
                    }
                    );
            }
        }
    }
}
