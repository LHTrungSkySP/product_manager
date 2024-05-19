using Application.GroupPermissions.Dto;
using Application.GroupPermissions.Queries;
using AutoMapper;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GroupPermissions.QueryHandlers
{
    public class GetGroupPermissionByIdHandler : IRequestHandler<GetGroupPermissionById, GroupPermissionDto>
    {
        private BanHangContext _context;
        private readonly IMapper _mapper;

        public GetGroupPermissionByIdHandler(BanHangContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GroupPermissionDto> Handle(GetGroupPermissionById request, CancellationToken cancellationToken)
        {
            return _mapper.Map<GroupPermissionDto>(_context.GroupPermissions.Where(e => e.Id == request.Id).Include(x =>x.AssignPermissions).FirstOrDefault());
        }
    }
}
