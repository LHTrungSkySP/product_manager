using Application.GroupPermissions.Commands;
using Application.GroupPermissions.Dto;
using Application.GroupPermissions.Queries;
using Microsoft.AspNetCore.Mvc;
using Web.API.Atributes;

namespace Web.API.Controllers
{
    [AllowAnonymous]
    public class GroupPermissionsController : ApiControllerBase
    {

        [HttpPost()]
        public async Task<ActionResult<GroupPermissionDto>> Create(CreateGroupPermissionCommand registerRequest)
        {
            return await Mediator.Send(registerRequest);
        }
        [HttpGet("filter")]
        public async Task<ActionResult<List<GroupPermissionDto>>> GetAll([FromQuery] FilterGroupPermission data)
        {
            return await Mediator.Send(data);
        }
        [HttpPut]
        public async Task<ActionResult<GroupPermissionDto>> Update(UpdateGroupPermissionCommand updateRequest)
        {
            return await Mediator.Send(updateRequest);
        }
        [HttpDelete]
        public async Task<ActionResult<GroupPermissionDto>> Delete([FromQuery] DeleteGroupPermissionCommand deleteGroupPermissionCommand)
        {
            return await Mediator.Send(deleteGroupPermissionCommand);
        }
        [HttpGet("get-by-id")]
        public async Task<ActionResult<GroupPermissionDto>> Get([FromQuery] GetGroupPermissionById getById)
        {
            return await Mediator.Send(getById);
        }
    }
}
