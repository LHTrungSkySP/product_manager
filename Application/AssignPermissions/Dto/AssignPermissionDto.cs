using Application.Common.Mapping;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AssignPermissions.Dto
{
    public class AssignPermissionDto : IMapFrom<AssignPermission>
    {
        public int PermissionId { get; set; }
        public int GroupPermissionId { get; set; }
    }
}
