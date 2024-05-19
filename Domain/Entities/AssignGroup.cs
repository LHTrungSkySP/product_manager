using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AssignGroup: BaseModel
    {
        public int AccountId { get; set; }
        public int GroupPermissionId { get; set; }
        [ForeignKey(nameof(AccountId))]
        public virtual Account? Account { get; set; }
        [ForeignKey(nameof(GroupPermissionId))]
        public virtual GroupPermission? GroupPermission{ get; set; }
    }
}
