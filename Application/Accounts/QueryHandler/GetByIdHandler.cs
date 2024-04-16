using Application.Accounts.Dto;
using Application.Accounts.Queries;
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

namespace Application.Accounts.QueryHandler
{
    public class GetByIdHandler : IRequestHandler<GetById, AccountDto>
    {
        private BanHangContext _context;
        private readonly IMapper _mapper;

        public GetByIdHandler(BanHangContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AccountDto> Handle(GetById model, CancellationToken cancellationToken)
        {
            Account? account = _context.Accounts.Find(model.Id);
            if (account != null)
            {
                return _mapper.Map<AccountDto>(_context.Accounts.Find(model.Id));
            }
            throw new AppException("Không tồn tại tài khoản này!");
        }
    }
}
