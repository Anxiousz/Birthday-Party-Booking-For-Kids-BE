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
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private IRegisteredUserService _registeredUserService;
        public LoginController(IConfiguration config, IRegisteredUserService registeredUserService)
        {
            _config = config;
            _registeredUserService = registeredUserService;
        }

        [AllowAnonymous]
        [HttpPost]
        [EnableCors]
        public IActionResult Login([FromBody] RegisteredUser registeredUser)
        {
            IActionResult response = Unauthorized();
            var user = _registeredUserService.GetRegisteredUserAccount(registeredUser.Email.Trim(),registeredUser.Password.Trim());

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string GenerateJSONWebToken(RegisteredUser userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
