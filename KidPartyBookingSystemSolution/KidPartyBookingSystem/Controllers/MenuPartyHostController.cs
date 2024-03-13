using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace KidPartyBookingSystem.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    [Authorize (Roles = "3")]
    public class MenuPartyHostController : ControllerBase
    {
        private static String NOT_FOUND = "Hien tai khong tim thay du lieu";
        private IMenuPartyHostService _menuPartyHostService;
        private IConfiguration _config;
        public MenuPartyHostController(IMenuPartyHostService menuPartyHostService, IConfiguration config)
        {
            _menuPartyHostService = menuPartyHostService;
            _config = config;
        }

        // Get Menu Party Host
        [HttpGet("PartyHostId")]
        public IActionResult GetMenuPartyHost(int? partyHostid)
        {
            var menuPartyHost = _menuPartyHostService.getListMenuPartyHost(partyHostid);
            if (menuPartyHost == null)
            {
                return NotFound(NOT_FOUND);
            }
            return Ok(menuPartyHost);
        }

        [HttpGet("GetOneFood/{id}")]
        public IActionResult GetMenuFoodById(int id)
        {
            var food = _menuPartyHostService.getMenuPartyHostFoodById(id);
            if (food == null)
            {
                return NotFound(NOT_FOUND);
            }
            return Ok(food);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteMenuFoodById(int id)
        {
            if (_menuPartyHostService.deleteMenuPartyHost(id) == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Hien tai khong the xoa duoc mon an nay");
            }
        }

    }
}

