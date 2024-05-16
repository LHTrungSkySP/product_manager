using Application.GroupPermissions.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GroupPermissions.Commands
{
    public class DeleteGroupPermissionCommand : IRequest<GroupPermissionDto>
    {
        public int Id { get; set; }
    }
}
