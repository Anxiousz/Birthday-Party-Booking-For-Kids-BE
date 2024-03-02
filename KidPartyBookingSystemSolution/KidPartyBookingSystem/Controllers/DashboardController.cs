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
    //[Authorize(Roles = "1")]
    public class DashboardController : ControllerBase
    {
        private IRegisteredUserService _registeredUserService;
        private IPartyHostService _partyHostService;
        private IStaffService _staffService;
        private IPackageService _packageService;
        private IBookingService _bookingService;
        private IConfigService _configService;
        public DashboardController(IRegisteredUserService registeredUserService, IPartyHostService partyHostService, IStaffService staffService, IPackageService packageService, IBookingService bookingService, IConfigService configService)
        {
            _registeredUserService = registeredUserService;
            _partyHostService = partyHostService;
            _staffService = staffService;
            _packageService = packageService;
            _bookingService = bookingService;
            _configService = configService;
        }

        [HttpGet("RegisteredUser")]
        public IActionResult GetRegisteredUser()
        {
            var registeredUser = _registeredUserService.GetRegisteredUser();
            if (registeredUser != null)
            {
                return Ok(registeredUser);
            }
            return NotFound();
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

        [HttpDelete("RegisteredUser/{id}")]
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

        [HttpGet("RegisteredUser/search/{context}")]
        public IActionResult searchRegisteredUser(string context)
        {
            List<RegisteredUser> searchAccount = _registeredUserService.searchRegisteredUser(context);
            return Ok(searchAccount);
        }

        [HttpGet("Account/total")]
        public IActionResult CountAccount()
        {
            int countAccount = _partyHostService.CountPartyHost() + _registeredUserService.CountRegisteredUser() + _staffService.CountStaff();
            return Ok(countAccount);
        }

        [HttpGet("PartyHost")]
        public IActionResult GetPartyHost()
        {
            var partyHost = _partyHostService.GetPartyHost();
            if (partyHost != null)
            {
                return Ok(partyHost);
            }
            return NotFound();
        }

        [HttpGet("PartyHost/search/{context}")]
        public IActionResult searchPartyHost(string context)
        {
            List<PartyHost> searchPartyHost = _partyHostService.searchPartyHost(context);
            return Ok(searchPartyHost);
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

        [HttpDelete("PartyHost/{id}")]
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

        [HttpGet("Staff")]
        public IActionResult GetStaff()
        {
            var staff = _staffService.GetStaff();
            if (staff != null)
            {
                return Ok(staff);
            }
            return NotFound();
        }

        [HttpGet("Staff/search/{context}")]
        public IActionResult searchStaff(string context)
        {
            List<staff> searchStaff = _staffService.SearchStaff(context);
            return Ok(searchStaff);
        }

        [HttpPost("Staff")]
        public IActionResult CreateStaff([FromBody] RequestStaffDTO request)
        {
            if (request == null)
            {
                return BadRequest("The field not empty");
            }
            bool checkExisted = _staffService.checkStaffExistedByEmail(request.Email.Trim());
            if (checkExisted != true)
            {
                RequestStaffDTO createAccount = _staffService.createStaff(request);
                return Ok(createAccount);
            }
            return Conflict("The user is existed");
        }

        [HttpDelete("Staff/{id}")]
        public IActionResult DeleteStaff(int id)
        {
            staff checkExisted = _staffService.checkStaffExistedByID(id);
            if (checkExisted != null)
            {
                bool deleteAccount = _staffService.DeleteStaff(id);
                return Ok("Delete " + checkExisted.Email + " successfully");
            }
            return NotFound("The user not found");
        }

        [HttpGet("Package/total")]
        public IActionResult CountPackage()
        {
            int countPackage = _packageService.CountPackage();
            return Ok(countPackage);
        }

        [HttpGet("Package")]
        public IActionResult GetAllPackages()
        {
            var package = _packageService.GetAllPackages();
            if (package != null)
            {
                return Ok(package);
            }
            return NotFound();
        }

        [HttpGet("Package/{id}")]
        public IActionResult GetPackage(int id)
        {
            var package = _packageService.GetPackageById(id);
            if (package != null)
            {
                return Ok(package);
            }
            return NotFound();
        }

        [HttpPost("Package")]
        public IActionResult CreatePackage([FromBody] RequestPackageCreateDTO request)
        {
            var package = _packageService.CreatePackage(request);
            if (package != null)
            {
                return Ok(package);
            }
            return NotFound();
        }
        [HttpDelete("Package")]
        public IActionResult DeletePackage(int id)
        {
            var checkExisted = _partyHostService.checkPackageExisted(id);
            if (checkExisted != null)
            {
                return Conflict("The package has been used");
            }
            bool deletePackage = _packageService.deletePackage(id);
            return Ok("Delete package successfully");
        }

        [HttpPut("Package")]
        public IActionResult UpdatePackage(RequestPackageUpdateDTO request)
        {
            var checkExisted = _packageService.GetPackageByID(request.PackageId);
            if (checkExisted != null)
            {
                RequestPackageUpdateDTO updatePackage = _packageService.UpdatePackage(request);
                return Ok("Update package successfully");
            }
            return NotFound();
        }

        [HttpGet("Order")]
        public IActionResult ViewOrder()
        {
            var booking = _bookingService.GetOrders();
            if (booking != null)
            {
                return Ok(booking);
            }
            return NotFound();
        }

        [HttpPost("Config")]
        public IActionResult CreateConfig([FromBody] RequestConfigDTO request)
        {
            var config = _configService.CreateConfig(request);
            if (config != null)
            {
                return Ok(config);
            }
            return BadRequest();
        }

        [HttpPut("Config")]
        public IActionResult UpdateConfig([FromBody] RequestUpdateConfigDTO request)
        {
            var checkExisted = _configService.checkConfigByID(request.ConfigId);
            if (checkExisted != null)
            {
                var UpdateConfig = _configService.UpdateConfig(request);
                return Ok(UpdateConfig);
            }
            return NotFound();
        }

        [HttpGet("Config")]
        public IActionResult GetConfig()
        {
            var config = _configService.GetConfig();
            if (config != null)
            {
                return Ok(config);
            }
            return NotFound();
        }
        [HttpGet("Config/{id}")]
        public IActionResult GetConfigByID(int id)
        {
            var config = _configService.checkConfigByID(id);
            if (config != null)
            {
                return Ok(config);
            }
            return NotFound();
        }
    }
}
