using Application.Accounts.CommandHandlers;
using Application.Accounts.Commands;
using Application.Accounts.Queries;
using Application.Accounts.QueryHandler;
using Application.Authenticates.Dto;
using Application.Authenticates.Queries;
using Application.Authenticates.QueryHandlers;
using AutoMapper;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Utility.Authorizations;
using WebAPI.Authorization;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(Authenticate model)
        {
            return Ok(await _mediator.Send(model));
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Create(CreateAccountCommand registerRequest)
        {
            return Ok(await _mediator.Send(registerRequest));
        }
        [HttpGet("get-list")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAll()));
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAccountCommand updateRequest)
        {
            return Ok(await _mediator.Send(updateRequest));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteAccountCommand deleteAccountCommand)
        {
            return Ok(await _mediator.Send(deleteAccountCommand));
        }
        [HttpGet("get-by-id")]
        public async Task<IActionResult> Get([FromQuery] GetById getById)
        {
            return Ok(await _mediator.Send(getById));
        }

    }
}
