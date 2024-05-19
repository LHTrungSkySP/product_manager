using Application.GroupPermissions.Commands;
using Application.GroupPermissions.Dto;
using Application.Accounts.Commands;
using Application.Accounts.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using AutoMapper;
using Infrastructure;
using Common.Exceptions;

namespace Application.GroupPermissions.CommandHandlers
{
    public class UpdateGroupPermissionCommandHandler : IRequestHandler<UpdateGroupPermissionCommand, GroupPermissionDto>
    {
        private BanHangContext _context;
        private readonly IMapper _mapper;

        public UpdateGroupPermissionCommandHandler(BanHangContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GroupPermissionDto> Handle(UpdateGroupPermissionCommand request, CancellationToken cancellationToken)
        {
            // find item need update
            GroupPermission groupPermission = _context.GroupPermissions.Find(request.Id, cancellationToken) ?? throw new AppException(
                ExceptionCode.Notfound,
                "Không tìm thấy GroupPermission"
                );
            groupPermission.Title = request.Title;
            groupPermission.Description = request.Description;
            groupPermission.AssignPermissions = request.AssignPermissionIds.Select(t => new AssignPermission()
            {
                PermissionId = t,
                GroupPermissionId = groupPermission.Id
            }).ToList();

            groupPermission.AssignGroups = request.AssignGroupIds.Select(t => new AssignGroup()
            {
                AccountId = t,
                GroupPermissionId = groupPermission.Id
            }).ToList();

            _context.GroupPermissions.Update(groupPermission);
            _context.SaveChanges();
            return _mapper.Map<GroupPermissionDto>(groupPermission);
        }
    }
}
