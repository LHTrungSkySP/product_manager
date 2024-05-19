

using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Permission : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public List<AssignPermission> AssignPermissions = new List<AssignPermission>();
    }
}
