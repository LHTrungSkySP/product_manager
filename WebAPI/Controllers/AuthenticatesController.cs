using Application.Authenticates.Dto;
using Application.Authenticates.Queries;
using Microsoft.AspNetCore.Mvc;
using Web.API.Atributes;

namespace Web.API.Controllers
{
    [AllowAnonymous]
    public class AuthenticatesController : ApiControllerBase
    {
        [HttpGet("login")]
        public async Task<ActionResult<AuthenticateDto>> Get([FromQuery] Authenticate getById)
        {
            return await Mediator.Send(getById);
        }
    }
}
