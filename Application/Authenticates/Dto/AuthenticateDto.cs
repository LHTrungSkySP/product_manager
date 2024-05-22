using Application.Common.Mapping;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authenticates.Dto
{
    public class AuthenticateDto : IMapFrom<Account>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }
}