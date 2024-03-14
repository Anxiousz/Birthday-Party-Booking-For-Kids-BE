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


    public CheckoutController(PayOS payOS, IRoomService roomService)
    {
        _payOS = payOS;
        _roomService = roomService;

    }

    [HttpGet("/")]
    public IActionResult Index()
    {
        return View("index");
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
         //   var MenuOrder = _roomService.Get

            int orderCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"));
            ItemData item = new ItemData("Mì tôm hảo hảo ly", 1, 10000);
            List<ItemData> items = new List<ItemData>();
            items.Add(item);
            PaymentData paymentData = new PaymentData(orderCode, Room.Price  , "Thanh toan don hang", items, "http://localhost:5267/cancel", "http://localhost:5267/success");

            CreatePaymentResult createPayment = await _payOS.createPaymentLink(paymentData);
            return Ok(createPayment.checkoutUrl);
        }
        catch (System.Exception exception)
        {
            Console.WriteLine(exception);
            return Redirect("http://localhost:5267/");
        }
    }
}
