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
    public class UpdateAccountCommand : AccountDto, IRequest<AccountDto>
    {
        public string PasswordNew { get; set; }
        public string PasswordOld { get; set; }
        public List<AssignGroup> AssignGroups { get; set; } = new List<AssignGroup>();
    }
}
