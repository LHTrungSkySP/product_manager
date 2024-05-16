using Application.Permissions.Dto;
using Application.Permissions.Queries;
using AutoMapper;
using Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Permissions.QueryHandlers
{
    public class FilterPermissionHandler : IRequestHandler<FilterPermission, List<PermissionDto>>
    {
        private BanHangContext _context;
        private readonly IMapper _mapper;

        public FilterPermissionHandler(BanHangContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<PermissionDto>> Handle(FilterPermission request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<PermissionDto>>(_context.Permissions);
        }
    }
}
