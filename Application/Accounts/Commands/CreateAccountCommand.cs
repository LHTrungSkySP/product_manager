using Application.Accounts.Dto;
using Application.Common.Mapping;
using Domain.Entities;
using MediatR;

namespace Application.Accounts.Commands
{
    public class CreateAccountCommand : IRequest<AccountDto>, IMapTo<Account>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public List<int>? GroupPermissionIds { get; set; } = new List<int>();
    }
}

