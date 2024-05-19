using Application.Accounts.Dto;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Accounts.Commands
{
    public class CreateAccountCommand : IRequest<AccountDto>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public List<int>? groupPermissionId { get; set; } = new List<int>();
    }
}
