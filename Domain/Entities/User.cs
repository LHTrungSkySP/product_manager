using Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User: BaseModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Gender gender { get; set; }
        public int NumberWin { get; set; } = 0;
        public int NumberBattle { get; set; } = 0;
        public int NumberSteak { get; set; } = 0;
        public int Gold { get; set; } = 0;
    }
}
