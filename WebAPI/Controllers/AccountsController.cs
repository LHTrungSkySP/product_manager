using Application.Accounts.CommandHandlers;
using Application.Accounts.Commands;
using Application.Accounts.Queries;
using Application.Accounts.QueryHandler;
using Application.Authenticates.Queries;
using Application.Authenticates.QueryHandlers;
using AutoMapper;
using Infrastructure;
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
        private BanHangContext _context;
        private readonly IMapper _mapper;
        private readonly IJwtUtils _jwtUtils;
        public AccountsController(BanHangContext context, IMapper mapper, IJwtUtils jwtUtils)
        {
            _context = context;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(Authenticate model)
        {
            AuthenticateHandler authenticate = new AuthenticateHandler(_context, _mapper, _jwtUtils);
            var response = authenticate.Authenticate(model);
            return Ok(response);
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Create(CreateAccountCommand registerRequest)
        {
            CreateAccountCommandHandler createAccountCommand = new CreateAccountCommandHandler(_context, _mapper);
            createAccountCommand.Register(registerRequest);
            return Ok(new { message = "Create success " + registerRequest.AccountName });
        }
        [HttpGet("get-list")]
        public IActionResult GetAll()
        {
            GetAllHandler getAllHandler = new GetAllHandler(_context, _mapper);
            return Ok(getAllHandler.GetAccounts());
        }
        [HttpPut]
        public IActionResult Update(int id, UpdateAccountCommand updateRequest)
        {
            UpdateAccountCommandHandler updateAccountCommandHandler = new UpdateAccountCommandHandler(_context, _mapper);
            updateAccountCommandHandler.Update(id, updateRequest);
            return Ok(new { message = "Update success " + updateRequest.AccountName });
        }
        [HttpDelete]
        public IActionResult Delete(DeleteAccountCommand deleteAccountCommand)
        {
            DeleteAccountCommandHandler deleteAccountCommandHandler = new DeleteAccountCommandHandler(_context);
            deleteAccountCommandHandler.Delete(deleteAccountCommand);
            return Ok(new { message = "Delete success" });
        }
        [HttpGet("get-by-id")]
        public IActionResult Get(GetById id)
        {
            GetByIdHandler getByIdHandler = new GetByIdHandler(_context);
            return Ok(getByIdHandler.GetById(id));
        }

    }
}
