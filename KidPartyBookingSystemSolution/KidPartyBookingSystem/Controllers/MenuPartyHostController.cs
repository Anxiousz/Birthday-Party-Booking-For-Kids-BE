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

        public MenuPartyHostController(IMenuPartyHostService menuPartyHostService)
        {
            _menuPartyHostService = menuPartyHostService;
        }

        [HttpGet("{id}")]
        [ActionName("Get All Menu Party Host")]
        public IActionResult GetAllMenuById(int id)
        {
            var menuPartyHost = _menuPartyHostService.getListMenuPartyHost(id);
            if (menuPartyHost == null)
            {
                return NotFound(NOT_FOUND);
            }
            return Ok(menuPartyHost);
        }

        [HttpGet("/MenuPartyHost/{id}")]
        [ActionName("Get One Food By Menu Party Host")]
        public IActionResult GetMenuFoodById(int id)
        {
            var food = _menuPartyHostService.getMenuPartyHostFoodById(id);
            if (food == null)
            {
                return NotFound(NOT_FOUND);
            }
            return Ok(food);
        }

        [HttpDelete("/MenuPartyHost/{id}")]
        [ActionName("Delete Food Menu By Party Host")]
        public IActionResult DeleteMenuFoodById(int id)
        {
           if(_menuPartyHostService.deleteMenuPartyHost(id) == true)
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

