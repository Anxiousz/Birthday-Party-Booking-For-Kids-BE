using Azure.Core;
using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Services;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace KidPartyBookingSystem.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RegisteredUserController : ControllerBase
    {
        private IRegisteredUserService _registeredUserService;
        public RegisteredUserController(IRegisteredUserService registeredUserService)
        {
            _registeredUserService = registeredUserService;
        }

        [HttpGet]
        public IActionResult GetRegisteredUser()
        {
            var registeredUser = _registeredUserService.GetRegisteredUser();
            if (registeredUser != null)
            {
                return Ok(registeredUser);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateRegisteredUser([FromBody] RegisteredUser request)
        {
            if (request == null)
            {
                return BadRequest("The field not empty");
            }
            bool checkExisted = _registeredUserService.checkRegisteredUserExistedByEmail(request.Email.Trim());
            if (checkExisted != true)
            {
                RegisteredUser createAccount = _registeredUserService.CreateRegisteredUser(request);
                return Ok(createAccount);
            }
            return Conflict("The user is existed");
        }

        [HttpDelete]
        public IActionResult DeleteRegisteredUser(int id)
        {
            RegisteredUser checkExisted = _registeredUserService.checkRegisteredUserExistedByID(id);
            if (checkExisted != null)
            {
                bool deleteAccount = _registeredUserService.DeleteRegisteredUser(id);
                return Ok("Delete " + checkExisted.Email + " successfully");
            }
            return NotFound("The user not found");
        }

        [HttpPut]
        public IActionResult UpdateRegisteredUser([FromBody] RegisteredUser request)
        {
            if (request == null)
            {
                return BadRequest("The field not empty");
            }
            RegisteredUser checkExisted = _registeredUserService.checkRegisteredUserExistedByID(request.AccountId);
            if (checkExisted != null)
            {
                RegisteredUser updateAccount = _registeredUserService.UpdateRegisteredUser(request);
                return Ok(updateAccount);
            }
            return NotFound("The user not found");
        }
    }       
}
