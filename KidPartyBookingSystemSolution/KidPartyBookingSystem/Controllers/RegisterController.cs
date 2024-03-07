using BusinessObjects.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace KidPartyBookingSystem.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [AllowAnonymous]
    [EnableCors]
    public class RegisterController : ControllerBase
    {
        private IRegisteredUserService _registeredUserService;
        private IPartyHostService _partyHostService;
        public RegisterController(IRegisteredUserService registeredUserService, IPartyHostService partyHostService)
        {
            _registeredUserService = registeredUserService;
            _partyHostService = partyHostService;
        }

        [HttpPost("RegisteredUser")]
        public IActionResult CreateRegisteredUser([FromBody] RequestRegisteredUserDTO request)
        {
            if (request == null)
            {
                return BadRequest("The field not empty");
            }
            bool checkExisted = _registeredUserService.checkRegisteredUserExistedByEmail(request.Email.Trim());
            if (checkExisted != true)
            {
                RequestRegisteredUserDTO createAccount = _registeredUserService.CreateRegisteredUser(request);
                return Ok(createAccount);
            }
            return Conflict("The user is existed");
        }

        [HttpPost("PartyHost")]
        public IActionResult CreatePartyHost([FromBody] RequestPartyHostDTO request)
        {
            if (request == null)
            {
                return BadRequest("The field not empty");
            }
            bool checkExisted = _partyHostService.checkPartyHostExistedByEmail(request.Email.Trim());
            if (checkExisted != true)
            {
                RequestPartyHostDTO createAccount = _partyHostService.CreatePartyHost(request);
                return Ok(createAccount);
            }
            return Conflict("The user is existed");
        }
    }
}
