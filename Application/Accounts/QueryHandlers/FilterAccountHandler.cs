using Application.Accounts.Dto;
using Application.Accounts.Queries;
using AutoMapper;
using Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Accounts.QueryHandlers
{
    public class FilterAccountHandler : IRequestHandler<FilterAccount, List<AccountDto>>
    {
        private BanHangContext _context;
        private readonly IMapper _mapper;

        public FilterAccountHandler(BanHangContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<AccountDto>> Handle(FilterAccount request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<AccountDto>>(_context.Accounts);
        }
    }
}
