using Application.Permissions.Commands;
using Application.Permissions.Dto;
using AutoMapper;
using Common.Exceptions;
using Domain.Entities;
using Infrastructure;
using MediatR;

namespace Application.Permissions.CommandHandlers
{
    public class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand, PermissionDto>
    {
        private BanHangContext _context;
        private readonly IMapper _mapper;

        public UpdatePermissionCommandHandler(BanHangContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PermissionDto> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            Permission permission = _context.Permissions.Find(request.Id) ??
                throw new AppException(
                    ExceptionCode.Notfound,
                    "Không tìm thấy Permission " + request.Title,
                                        new[] {
                        new ErrorDetail(
                            nameof(request.Title),
                            request.Title)
                    }
                    );
            permission.Title = request.Title;
            permission.Description = request.Description;
            permission.UpdatesdDate = new DateTime();
            _context.Permissions.Update(permission);
            _context.SaveChanges();
            return _mapper.Map<PermissionDto>(permission);
        }
    }
}
