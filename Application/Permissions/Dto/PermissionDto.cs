using Application.Common.Mapping;
using Domain.Entities;
using System.Text.Json.Serialization;

namespace Application.Permissions.Dto
{
    public class PermissionDto: IMapFrom<Permission>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public virtual List<GroupPermissionDto> GroupPermissions { get; set; } = new List<GroupPermissionDto>();
    }
}
