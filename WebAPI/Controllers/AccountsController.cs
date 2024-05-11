using Application.Accounts.Commands;
using Application.Accounts.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.API.Atributes;

namespace Web.API.Controllers
{
    public class AccountsController : ApiControllerBase
    {
        [AllowAnonymous]
        [HttpPost()]
        public async Task<IActionResult> Create(CreateAccountCommand registerRequest)
        {
            return Ok(await Mediator.Send(registerRequest));
        }
        [HttpGet("get-list")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAll()));
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAccountCommand updateRequest)
        {
            return Ok(await Mediator.Send(updateRequest));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteAccountCommand deleteAccountCommand)
        {
            return Ok(await Mediator.Send(deleteAccountCommand));
        }
        [HttpGet("get-by-id")]
        public async Task<IActionResult> Get([FromQuery] GetById getById)
        {
            return Ok(await Mediator.Send(getById));
        }

    }
}
