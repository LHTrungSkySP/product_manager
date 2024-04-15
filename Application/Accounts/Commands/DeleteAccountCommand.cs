using Common.Exceptions;
using Domain.Entities;
using Infrastructure;

namespace Application.Accounts.Commands
{
    public class DeleteAccountCommand
    {
        public int Id { get; set; }
    }
}
