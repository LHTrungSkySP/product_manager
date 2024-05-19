using Application.Common.Mapping;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.GroupPermissions.Dto
{
    public class GroupPermissionDto : IMapFrom<GroupPermission>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public virtual List<AccountDto>? Accounts { get; set; } = new List<AccountDto>();
        [JsonIgnore]

        public virtual List<PermissionDto>? Permissions { get; set; } = new List<PermissionDto>();
    }
}
