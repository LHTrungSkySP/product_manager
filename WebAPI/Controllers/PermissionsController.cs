using Application.Permissions.Commands;
using Application.Permissions.Dto;
using Application.Permissions.Queries;
using Microsoft.AspNetCore.Mvc;
using Web.API.Atributes;

namespace Web.API.Controllers
{
    [AllowAnonymous]
    public class PermissionsController : ApiControllerBase
    {
        //[HttpPost()]
        //public async Task<ActionResult<PermissionDto>> Create(CreatePermissionCommand registerRequest)
        //{
        //    return await Mediator.Send(registerRequest);
        //}
        //[HttpGet("filter")]
        //public async Task<ActionResult<List<PermissionDto>>> GetAll([FromQuery] FilterPermission data)
        //{
        //    return await Mediator.Send(data);
        //}
        //[HttpPut]
        //public async Task<ActionResult<PermissionDto>> Update(UpdatePermissionCommand updateRequest)
        //{
        //    return await Mediator.Send(updateRequest);
        //}
        //[HttpDelete]
        //public async Task<ActionResult<PermissionDto>> Delete([FromQuery] DeletePermissionCommand deletePermissionCommand)
        //{
        //    return await Mediator.Send(deletePermissionCommand);
        //}
        //[HttpGet("get-by-id")]
        //public async Task<ActionResult<PermissionDto>> Get([FromQuery] GetPermissionById getById)
        //{
        //    return await Mediator.Send(getById);
        //}
    }
}
