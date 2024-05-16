using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Permission : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual List<AssignPermission> AssignPermissions { get; set; } = new List<AssignPermission>();

    }
}
