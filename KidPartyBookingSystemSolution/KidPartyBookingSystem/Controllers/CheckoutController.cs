namespace NetCoreDemo.Controllers;
using Microsoft.AspNetCore.Mvc;
using Net.payOS.Types;
using Net.payOS;
using Microsoft.AspNetCore.Cors;
using Services;
using Microsoft.AspNetCore.Authorization;
using BusinessObjects.Request;

[EnableCors]
[Authorize(Roles = "4")]
public class CheckoutController : Controller
{
    private readonly PayOS _payOS;
    private IRoomService _roomService;
    private IMenuOrderService _menuOrderService;
    private IPaymentService _paymentService;
    private ITransactionBookingService _transactionBookingService;


    public CheckoutController(PayOS payOS, IRoomService roomService, IMenuOrderService menuOrderService, IPaymentService paymentService, ITransactionBookingService transactionBookingService)
    {
        _payOS = payOS;
        _roomService = roomService;
        _menuOrderService = menuOrderService;
        _paymentService = paymentService;
        _transactionBookingService = transactionBookingService;
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
    public async Task<IActionResult> Checkout([FromBody] RequestPaymentDTO request)
    {
        try
        {
            var Room = _roomService.GetRoomById(request.RoomID);
            var MenuOrder = _menuOrderService.getMenuOrder(request.MenuOrderID);
            int orderCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"));
            ItemData itemMenuOrder = new ItemData(MenuOrder.FoodName, 1, MenuOrder.TotalPrice);
            ItemData itemRoom = new ItemData(Room.RoomName, 1, Room.Price);
            List<ItemData> items = new List<ItemData>();
            items.Add(itemMenuOrder);
            items.Add(itemRoom);
            PaymentData paymentData = new PaymentData(orderCode, Room.Price + MenuOrder.TotalPrice  , "Thanh toan don hang", items, "https://partyhostingsystem.azurewebsites.net/cancel", "https://partyhostingsystem.azurewebsites.net/successs");

            CreatePaymentResult createPayment = await _payOS.createPaymentLink(paymentData);
            // Insert payment
            RequestCreatePaymentDTO payment = new RequestCreatePaymentDTO();
            payment.PaymentMethod = "Credit Card";
            payment.Amount = Room.Price + MenuOrder.TotalPrice;
            payment.CreateTime = DateTime.Now;
            payment.PaymentStatus = 1;
            var insertPayment = _paymentService.createPayment(payment);

            // Insert Transaction Booking
            RequestCreateTransactionBookingDTO transactionBooking = new RequestCreateTransactionBookingDTO();
            transactionBooking.PaymentId = insertPayment.PaymentId;
            var insertTransactionBooking = _transactionBookingService.CreateTransactionBooking(transactionBooking);
            return Ok(createPayment.checkoutUrl);
        }
        catch (System.Exception exception)
        {
            Console.WriteLine(exception);
            return BadRequest();
        }
    }
}
