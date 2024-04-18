using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.API.Atributes;

namespace Web.API
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        private IMediator? _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();

    }
}
