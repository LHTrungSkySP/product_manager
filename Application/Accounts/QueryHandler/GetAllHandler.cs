using Application.Accounts.Dto;
using AutoMapper;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Accounts.QueryHandler
{
    public class GetAllHandler
    {
        private BanHangContext _context;
        private readonly IMapper _mapper;

        public GetAllHandler(BanHangContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<AccountDto> GetAccounts()
        {
            return _mapper.Map<List<AccountDto>>(_context.Accounts);
        }
    }
}
