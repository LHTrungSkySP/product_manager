using Application.Accounts.Commands;
using Application.Accounts.Dto;
using Application.Accounts.Queries;
using Microsoft.AspNetCore.Mvc;
using Web.API.Atributes;

namespace Web.API.Controllers
{
    [AllowAnonymous]
    public class AccountsController : ApiControllerBase
    {
        [HttpPost()]
        public async Task<ActionResult<AccountDto>> Create(CreateAccountCommand registerRequest)
        {
            return await Mediator.Send(registerRequest);
        }
        [HttpGet("filter")]
        public async Task<ActionResult<List<AccountDto>>> GetAll([FromQuery] FilterAccount data)
        {
            return await Mediator.Send(data);
        }
        [HttpPut]
        public async Task<ActionResult<AccountDto>> Update(UpdateAccountCommand updateRequest)
        {
            return await Mediator.Send(updateRequest);
        }
        [HttpDelete]
        public async Task<ActionResult<AccountDto>> Delete([FromQuery] DeleteAccountCommand deleteAccountCommand)
        {
            return await Mediator.Send(deleteAccountCommand);
        }
        [HttpGet("get-by-id")]
        public async Task<ActionResult<AccountDto>> Get([FromQuery] GetAccountById getById)
        {
            return await Mediator.Send(getById);
        }
    }
}
