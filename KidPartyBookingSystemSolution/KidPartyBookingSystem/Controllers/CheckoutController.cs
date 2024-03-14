namespace NetCoreDemo.Controllers;
using Microsoft.AspNetCore.Mvc;
using Net.payOS.Types;
using Net.payOS;
using Microsoft.AspNetCore.Cors;
using Services;
using Microsoft.AspNetCore.Authorization;

[EnableCors]
[Authorize(Roles = "3")]
public class CheckoutController : Controller
{
    private readonly PayOS _payOS;
    private IRoomService _roomService;
    private IMenuOrderService _menuOrderService;


    public CheckoutController(PayOS payOS, IRoomService roomService, IMenuOrderService menuOrderService)
    {
        _payOS = payOS;
        _roomService = roomService;
        _menuOrderService = menuOrderService;

    }
    [HttpGet("/cancel")]
    public IActionResult Cancel()
    {
        return View("cancel");
    }
    [HttpGet("/success")]
    public IActionResult Success()
    {
        return View("success");
    }
    [HttpPost("/create-payment-link")]
    public async Task<IActionResult> Checkout(int RoomID , int MenuOrderID)
    {
        try
        {
            var Room = _roomService.GetRoomById(RoomID);
            var MenuOrder = _menuOrderService.getMenuOrder(MenuOrderID);

            int orderCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"));
            ItemData itemMenuOrder = new ItemData(MenuOrder.FoodName, 1, MenuOrder.TotalPrice);
            ItemData itemRoom = new ItemData(Room.RoomName, 1, Room.Price);
            List<ItemData> items = new List<ItemData>();
            items.Add(itemMenuOrder);
            items.Add(itemRoom);
            PaymentData paymentData = new PaymentData(orderCode, Room.Price + MenuOrder.TotalPrice  , "Thanh toan don hang", items, "https://partyhostingsystem.azurewebsites.net/cancel", "https://partyhostingsystem.azurewebsites.net/successs");

            CreatePaymentResult createPayment = await _payOS.createPaymentLink(paymentData);
            return Ok(createPayment.checkoutUrl);
        }
        catch (System.Exception exception)
        {
            Console.WriteLine(exception);
            return BadRequest();
        }
    }
}
