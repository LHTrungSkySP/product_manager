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
    public class GetPermissionByIdHandler : IRequestHandler<GetPermissionById, PermissionDto>
    {
        private BanHangContext _context;
        private readonly IMapper _mapper;

        public GetPermissionByIdHandler(BanHangContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PermissionDto> Handle(GetPermissionById request, CancellationToken cancellationToken)
        {
            return _mapper.Map<PermissionDto>(_context.Permissions.Find(request.Id));
        }
    }
}
