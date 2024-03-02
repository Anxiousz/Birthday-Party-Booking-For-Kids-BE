using BusinessObjects;
using BusinessObjects.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KidPartyBookingSystem.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LoginController : ControllerBase
    {
        private static string EMPTY_FILED = "The field must not be empty";
        private IConfiguration _config;

        private readonly IAdminService _adminService;
        private readonly IRegisteredUserService _registeredUserService;
        private readonly IStaffService _staffService;
        private readonly IPartyHostService _partyHostService;

        public LoginController(IConfiguration config, IAdminService adminService, IRegisteredUserService registeredUserService, IStaffService staffService, IPartyHostService partyHostService)
        {
            _config = config;
            _adminService = adminService;
            _registeredUserService = registeredUserService;
            _staffService = staffService;
            _partyHostService = partyHostService;
        }

        [AllowAnonymous]
        [HttpPost("Admin")]
        [EnableCors]
        public IActionResult LoginWithAdmin([FromBody] RequestAccountLoginDTO account)
        {
            if (account == null)
            {
                return BadRequest(EMPTY_FILED);
            }
            IActionResult response = Unauthorized();
            var user = _adminService.GetAdminAccount(account);

            if (user != null)
            {
                var tokenString = GenerateAdminJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string GenerateAdminJSONWebToken(Admin userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
                        {
                            new Claim("UserId", userInfo.AdminId.ToString()),
                            new Claim("Email", userInfo.Email),
                            new Claim("UserName", userInfo.UserName),
                            new Claim("Password", userInfo.Password),
                            new Claim(ClaimTypes.Role, userInfo.Role),
                            new Claim("Phone", userInfo.Phone),
                        };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost("RegisteredUser")]
        [EnableCors]
        public IActionResult LoginWithRegisteredUser([FromBody] RequestAccountLoginDTO account)
        {
            if (account == null)
            {
                return BadRequest(EMPTY_FILED);
            }
            IActionResult response = Unauthorized();
            var user = _registeredUserService.GetRegisteredUserAccount(account);

            if (user != null)
            {
                var tokenString = GenerateRegisteredUserJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string GenerateRegisteredUserJSONWebToken(RegisteredUser userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
                        {
                            new Claim("UserId", userInfo.AccountId.ToString()),
                            new Claim("Email", userInfo.Email),
                            new Claim("UserName", userInfo.UserName),
                            new Claim("Password", userInfo.Password),
                            new Claim(ClaimTypes.Role, userInfo.Role),
                            new Claim("Phone", userInfo.Phone),
                        };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost("Staff")]
        [EnableCors]
        public IActionResult LoginWithStaff([FromBody] RequestAccountLoginDTO account)
        {
            if (account == null)
            {
                return BadRequest(EMPTY_FILED);
            }
            IActionResult response = Unauthorized();
            var user = _staffService.GetStaffAccount(account);

            if (user != null)
            {
                var tokenString = GenerateStaffJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string GenerateStaffJSONWebToken(staff userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
                        {
                            new Claim("UserId", userInfo.StaffId.ToString()),
                            new Claim("Email", userInfo.Email),
                            new Claim("UserName", userInfo.UserName),
                            new Claim("Password", userInfo.Password),
                            new Claim(ClaimTypes.Role, userInfo.Role),
                            new Claim("Phone", userInfo.Phone),
                        };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
               _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost("PartyHost")]
        [EnableCors]
        public IActionResult LoginWithPartyHost([FromBody] RequestAccountLoginDTO account)
        {
            if (account == null)
            {
                return BadRequest(EMPTY_FILED);
            }
            IActionResult response = Unauthorized();
            var user = _partyHostService.GetPartyHostAccount(account);

            if (user != null)
            {
                var tokenString = GeneratePartyHostJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string GeneratePartyHostJSONWebToken(PartyHost userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
                        {
                            new Claim("UserId", userInfo.PartyHostId.ToString()),
                            new Claim("Email", userInfo.Email),
                            new Claim("UserName", userInfo.UserName),
                            new Claim("Password", userInfo.Password),
                            new Claim(ClaimTypes.Role, userInfo.Role),
                            new Claim("Phone", userInfo.Phone),
                        };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
               _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
