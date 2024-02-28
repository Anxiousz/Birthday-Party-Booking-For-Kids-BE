using Azure.Core;
using BusinessObjects;
using BusinessObjects.Request;
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
    [Authorize(Roles = "1")]
    public class DashboardController : ControllerBase
    {
        private IRegisteredUserService _registeredUserService;
        private IPartyHostService _partyHostService;
        public DashboardController(IRegisteredUserService registeredUserService, IPartyHostService partyHostService)
        {
            _registeredUserService = registeredUserService;
            _partyHostService = partyHostService;
        }

        [HttpGet("/RegisteredUser")]
        public IActionResult GetRegisteredUser()
        {
            var registeredUser = _registeredUserService.GetRegisteredUser();
            if (registeredUser != null)
            {
                return Ok(registeredUser);
            }
            return NotFound();
        }

        [HttpPost("/RegisteredUser")]
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

        [HttpDelete("/RegisteredUser/{id}")]
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

        [HttpGet("/RegisteredUser/search/{context}")]
        public IActionResult searchRegisteredUser(string context)
        {
            List<RegisteredUser> searchAccount = _registeredUserService.searchRegisteredUser(context);
            return Ok(searchAccount);
        }

        [HttpGet("/RegisteredUser/count")]
        public IActionResult CountRegistredUser()
        {
            return Ok(_registeredUserService.CountRegisteredUser());
        }

        [HttpGet("/PartyHost")]
        public IActionResult GetPartyHost()
        {
            var partyHost = _partyHostService.GetPartyHost();
            if (partyHost != null)
            {
                return Ok(partyHost);
            }
            return NotFound();
        }

        [HttpGet("/PartyHost/search/{context}")]
        public IActionResult searchAccount(string context)
        {
            List<PartyHost> searchAccount = _partyHostService.searchPartyHost(context);
            return Ok(searchAccount);
        }

        [HttpPost("/PartyHost")]
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

        [HttpDelete("/PartyHost/{id}")]
        public IActionResult DeletePartyHost(int id)
        {
            PartyHost checkExisted = _partyHostService.checkPartyHostExistedByID(id);
            if (checkExisted != null)
            {
                bool deleteAccount = _partyHostService.DeletePartyHost(id);
                return Ok("Delete " + checkExisted.Email + " successfully");
            }
            return NotFound("The user not found");
        }
    }
}
