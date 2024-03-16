using Azure.Core;
using BusinessObjects;
using BusinessObjects.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace KidPartyBookingSystem.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
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
        [Authorize(Roles = "3")]
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
        [Authorize(Roles = "3")]
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

        // Create Manu Party Host
        [HttpPost("CreateMenuPartyHost")]
        //[Authorize(Roles ="3")]
        public IActionResult CreateMenuFood([FromBody] RequestMenuPartyHostDTO menu)
        {
            if (menu == null)
            {
                return BadRequest("Fill Full empty fields please!!");
            }
            else
            {
                _menuPartyHostService.createNewMenuPartyHost(menu);
                return Ok(menu);
            }
        }

        // Update Menu Party Host
        [HttpPost("UpdateMenuPartyHostV2")]
        [Authorize(Roles = "3")]
        public IActionResult UpdateMenuFoodV2([FromBody] RequestUpdateMenuPartyHostDTO menu)
        {
            if (menu == null)
            {
                return BadRequest("Fill Full empty fields please!!");
            }
            else
            {
                if (_menuPartyHostService.updateMenuPartyHostv2(menu) == true)
                {
                    return Ok(menu);
                }
                else
                {
                    return BadRequest("Update failed");
                }
                
            }
        }


        // Get All Menu Party Host 
        [HttpGet("GetAllMenuPartyHost")]
        [Authorize(Roles ="3")]
        public IActionResult GetAllMenuPartyHost()
        {
            List<MenuPartyHost> list = null; 
            list = _menuPartyHostService.getMenuPartyHosts();
            if (list == null)
            {
                return NotFound("Khong timf thay bat cu san pham nao!");
            }
            else
            {
                return Ok(list);
            }
        }
    }
}

