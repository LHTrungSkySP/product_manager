using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CaroLoginInfor: BaseModel
    {
        public int AccountId { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        [ForeignKey(nameof(AccountId))]
        public virtual Account? Account { get; set; }
    }
}
