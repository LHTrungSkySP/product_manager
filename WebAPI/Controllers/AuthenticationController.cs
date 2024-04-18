using Application.Authenticates.Queries;
using Microsoft.AspNetCore.Mvc;
using Web.API.Atributes;

namespace Web.API.Controllers
{
    public class AuthenticationController : ApiControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(ILogger<AuthenticationController> logger)
        {
            _logger = logger;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(Authenticate model)
        {
            _logger.LogInformation("000000000000000000000000");
            _logger.LogError("0000000000000000000000000000");
            _logger.LogCritical("000000000000000000000000000000000000000");
            _logger.LogDebug("000000000000000000000000000000000");
            _logger.LogWarning("00000000000000000000000000000000000");

            return Ok(await Mediator.Send(model));
        }
    }
}
