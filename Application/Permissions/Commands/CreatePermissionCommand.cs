using Application.Permissions.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Permissions.Commands
{
    public class CreatePermissionCommand : IRequest<PermissionDto>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
