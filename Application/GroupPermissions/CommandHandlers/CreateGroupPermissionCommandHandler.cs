using Application.GroupPermissions.Commands;
using Application.GroupPermissions.Dto;
using AutoMapper;
using Common.Exceptions;
using Domain.Entities;
using Infrastructure;
using MediatR;

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
            if (_context.GroupPermissions.Any(x => x.Title == request.Title))
            {
                throw new AppException(
                    ExceptionCode.Duplicate,
                    "Đã tồn tại GroupPermission " + request.Title,
                    new[] {
                        new ErrorDetail(
                            nameof(request.Title),
                            request.Title)
                    }
                );
            }
            GroupPermission groupPermission = new GroupPermission();
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

            _context.GroupPermissions.Add(groupPermission);
            _context.SaveChanges();
            return _mapper.Map<GroupPermissionDto>(groupPermission);
        }
    }
}
