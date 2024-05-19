using Application.Accounts.Dto;
using Application.Accounts.Queries;
using AutoMapper;
using Common.Exceptions;
using Domain.Entities;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Accounts.QueryHandlers
{
    public class GetAccountByIdHandler : IRequestHandler<GetAccountById, AccountDto>
    {
        private BanHangContext _context;
        private readonly IMapper _mapper;

        public GetAccountByIdHandler(BanHangContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<AccountDto> Handle(GetAccountById request, CancellationToken cancellationToken)
        {
            return _mapper.Map<AccountDto>(_context.Accounts.Where(x => x.Id == request.Id).Include(x => x.AssignGroup));
        }
    }
}
