using Application.Accounts.Commands;
using Application.Accounts.Queries;
using Application.Authenticates.Dto;
using Application.Authenticates.Queries;
using MediatR;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.API;
using Web.API.Atributes;

namespace WebAPI.Controllers
{
    public class AccountsController : ApiControllerBase
    {
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(Authenticate model)
        {
            return Ok(await Mediator.Send(model));
        }
        [AllowAnonymous]
        [HttpPost("register")]
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
