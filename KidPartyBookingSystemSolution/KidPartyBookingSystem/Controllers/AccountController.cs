using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace KidPartyBookingSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult getAllAccounts()
        {
            List<RegisteredUser> registeredUsers = _accountService.GetRegisteredUserAccount();
            return Ok(registeredUsers);
        }
    }
}
