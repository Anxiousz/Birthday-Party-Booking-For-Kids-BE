using BusinessObjects;
using BusinessObjects.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace KidPartyBookingSystem.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(Roles = "4")]
    public class RegisteredUserController : ControllerBase
    {
        private IRegisteredUserService _registeredUserService;
        private IConfigService _configService;
        public RegisteredUserController(IConfigService configService, IRegisteredUserService registeredUserService)
        {
            _registeredUserService = registeredUserService;
            _configService = configService;
        }

        [HttpGet("{id}")]
        public IActionResult GetRegisteredUserByID(int id)
        {
            RegisteredUser checkExisted = _registeredUserService.checkRegisteredUserExistedByID(id);
            if (checkExisted != null)
            {
                return Ok(checkExisted);
            }
            return NotFound("The user not found");
        }

        [HttpPut]
        public IActionResult UpdateRegisteredUser(RequestUpdateRegisteredUserDTO request)
        {
            RegisteredUser checkExisted = _registeredUserService.checkRegisteredUserExistedByID(request.AccountId);
            if (checkExisted != null)
            {
                RequestUpdateRegisteredUserDTO update = _registeredUserService.UpdateRegisteredUser(request);
                return Ok(update);
            }
            return NotFound("The user not found");
        }


    }
}
