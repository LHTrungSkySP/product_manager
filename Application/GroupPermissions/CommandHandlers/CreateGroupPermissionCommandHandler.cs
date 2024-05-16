using Application.GroupPermissions.Commands;
using Application.GroupPermissions.Dto;
using Application.Accounts.Commands;
using Application.Accounts.Dto;
using AutoMapper;
using Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GroupPermissions.CommandHandlers
{
    public class CreateGroupPermissionCommandHandler : IRequestHandler<CreateGroupPermissionCommand, GroupPermissionDto>
    {
        private BanHangContext _context;
        private readonly IMapper _mapper;

        public CreateGroupPermissionCommandHandler(BanHangContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GroupPermissionDto> Handle(CreateGroupPermissionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
