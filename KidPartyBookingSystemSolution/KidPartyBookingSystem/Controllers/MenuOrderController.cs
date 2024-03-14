using BusinessObjects;
using BusinessObjects.Request;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Impl;

namespace KidPartyBookingSystem.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MenuOrderController : ControllerBase
    {
        private static String NOT_FOUND = "Not found Menu";
        private static String NULL_ERROR = "Null Error";

        private IMenuOrderService _menuPartyHostService;
        public MenuOrderController(IMenuOrderService menuPartyHostService)
        {
            _menuPartyHostService = menuPartyHostService;
        }

        // Get Menu By ID ( Party host )
        [HttpGet("GetMenuOrderByID/{id}")]
        public IActionResult getMenuOrderByID(int id)
        {
            var menuorder = _menuPartyHostService.getMenuOrder(id);
            if (menuorder == null)
            {
                return NotFound(NOT_FOUND);
            }
            return Ok(menuorder);
        }


        [HttpPost("CreateNewMenuOrder")]
        public IActionResult createMenuOrder([FromBody] RequestMenuOrderDTO requestMenuOrderDTO)
        {
            try
            {
                if (requestMenuOrderDTO == null)
                {
                    return BadRequest(NULL_ERROR);
                }
                else
                {
                    MenuOrder order = _menuPartyHostService.createMenuOrderFull(requestMenuOrderDTO);
                    return Ok(order);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
