using Application.Permissions.Commands;
using Application.Permissions.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.API.Atributes;

namespace Web.API.Controllers
{
    public class PermissionController : ApiControllerBase
    {
        [AllowAnonymous]
        [HttpPost()]
        public async Task<IActionResult> Create(CreatePermissionCommand registerRequest)
        {
            return Ok(await Mediator.Send(registerRequest));
        }
        [HttpGet("get-list")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAll()));
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdatePermissionCommand updateRequest)
        {
            return Ok(await Mediator.Send(updateRequest));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeletePermissionCommand deletePermissionCommand)
        {
            return Ok(await Mediator.Send(deletePermissionCommand));
        }
        [HttpGet("get-by-id")]
        public async Task<IActionResult> Get([FromQuery] GetById getById)
        {
            return Ok(await Mediator.Send(getById));
        }
    }
}
