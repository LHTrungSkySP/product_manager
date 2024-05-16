using Application.Accounts.Dto;
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
        public string Password { get; set; }
    }
}
