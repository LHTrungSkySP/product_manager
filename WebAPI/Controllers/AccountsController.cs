﻿using Application.Accounts.Commands;
using Application.Accounts.Dto;
using Application.Accounts.Queries;
using Application.GroupPermissions.Dto;
using Common.Constants;
using Microsoft.AspNetCore.Mvc;
using Web.API.Atributes;

namespace Web.API.Controllers
{
    public class AccountsController : ApiControllerBase
    {
        [HttpPost()]
        public async Task<ActionResult<Application.Accounts.Dto.AccountDto>> Create(CreateAccountCommand registerRequest)
        {
            return await Mediator.Send(registerRequest);
        }
        [Authorize(Permissions.VIEW_ACCOUNT)]
        [HttpGet("filter")]
        public async Task<ActionResult<List<Application.Accounts.Dto.AccountDto>>> GetAll([FromQuery] FilterAccount data)
        {
            return await Mediator.Send(data);
        }
        [HttpPut]
        public async Task<ActionResult<Application.Accounts.Dto.AccountDto>> Update(UpdateAccountCommand updateRequest)
        {
            return await Mediator.Send(updateRequest);
        }
        [HttpDelete]
        public async Task<ActionResult<Application.Accounts.Dto.AccountDto>> Delete([FromQuery] DeleteAccountCommand deleteAccountCommand)
        {
            return await Mediator.Send(deleteAccountCommand);
        }
        [HttpGet("get-by-id")]
        public async Task<ActionResult<Application.Accounts.Dto.AccountDto>> Get([FromQuery] GetAccountById getById)
        {
            return await Mediator.Send(getById);
        }
        [HttpGet("get-permission-by-id")]
        public async Task<ActionResult<AccountPermissionDto>> GetPermission([FromQuery] GetPermissionByAccountId getById)
        {
            return await Mediator.Send(getById);
        }
    }
}
