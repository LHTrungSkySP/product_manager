using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authenticates.Dto
{
    public class AuthenticateDto
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string Token { get; set; }
    }
}
