using BanHang.Authorization;
using BanHang.Models.Accounts;
using BanHang.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BanHang.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private IAccountService _accountService;
        public AccountsController(IAccountService accountService) 
        {
            _accountService= accountService;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _accountService.Authenticate(model);
            return Ok(response);
        }


        [HttpGet("get-list")]
        public IActionResult GetAll()
        {
            return Ok(_accountService.GetAccounts());
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Create(RegisterRequest registerRequest)
        {
            _accountService.Register(registerRequest);
            return Ok( new { message = "Create success " + registerRequest.AccountName} );
        }
        [HttpPut]
        public IActionResult Update(int id, UpdateRequest updateRequest)
        {
            _accountService.Update(id,updateRequest);
            return Ok( new { message = "Update success " + updateRequest.AccountName });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _accountService.Delete(id);
            return Ok(new { message = "Delete success" });
        }
        [HttpGet("get-by-id")] 
        public IActionResult Get(int id)
        {
            return Ok(_accountService.GetById(id));
        }

    }
}
