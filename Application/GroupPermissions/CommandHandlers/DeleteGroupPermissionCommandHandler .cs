using Application.GroupPermissions.Commands;
using Application.GroupPermissions.Dto;
using AutoMapper;
using Common.Exceptions;
using Domain.Entities;
using Infrastructure;
using MediatR;

namespace Application.GroupPermissions.CommandHandlers
{
    public class DeleteGroupPermissionCommandHandler : IRequestHandler<DeleteGroupPermissionCommand, GroupPermissionDto>
    {
        private BanHangContext _context;
        private readonly IMapper _mapper;

        public DeleteGroupPermissionCommandHandler(BanHangContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GroupPermissionDto> Handle(DeleteGroupPermissionCommand request, CancellationToken cancellationToken)
        {
            GroupPermission? groupPermission = _context.GroupPermissions.Find(request.Id, cancellationToken) ?? throw new AppException(
                ExceptionCode.Notfound,
                "Không tìm thấy GroupPermission "
                );
            _context.GroupPermissions.Remove(groupPermission);
            _context.SaveChanges();
            return _mapper.Map<GroupPermissionDto>(groupPermission);
        }
    }
}
