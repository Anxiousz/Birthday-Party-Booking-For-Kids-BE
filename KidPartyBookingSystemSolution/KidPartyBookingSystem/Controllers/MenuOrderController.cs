using Microsoft.AspNetCore.Mvc;
using Services;

namespace KidPartyBookingSystem.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MenuOrderController : ControllerBase
    {
        private IMenuOrderService _menuPartyHostService;
        public MenuOrderController(IMenuOrderService menuPartyHostService)
        {
            _menuPartyHostService = menuPartyHostService;
        }

/*        [HttpGet]
        [ActionName("Get Empty Menuorder")]
        public IActionResult CreateMenuorder()
        {

        }*/
    }
}
