using Application.Accounts.Commands;
using Application.Accounts.Dto;
using Application.Permissions.Commands;
using Application.Permissions.Dto;
using AutoMapper;
using Common.Exceptions;
using Domain.Entities;
using Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Permissions.CommandHandlers
{
    public class DeletePermissionCommandHandler : IRequestHandler<DeletePermissionCommand,PermissionDto>
    {
        private BanHangContext _context;
        private readonly IMapper _mapper;

        public DeletePermissionCommandHandler(BanHangContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PermissionDto> Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
        {
            Permission permission = _context.Permissions.Find(request.Id) ??
                throw new AppException(
                    ExceptionCode.Notfound,
                    "Không tìm thấy Permission "
                    );
            _context.Permissions.Remove(permission);
            _context.SaveChanges();
            return _mapper.Map<PermissionDto>(permission);
        }
    }
}
