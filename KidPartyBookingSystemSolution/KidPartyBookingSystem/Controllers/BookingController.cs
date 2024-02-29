using Microsoft.AspNetCore.Mvc;
using Services;

namespace KidPartyBookingSystem.Controllers
{
    [ApiController]
    [Route("/v1/api/{controller}")]
    public class BookingController : ControllerBase
    {
        private static String NOT_FOUND = "Hien tai chua ghi nhan thong tin";
        private IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost("/Booking/{roomID}")]
        [ActionName("Get Booking By Room ID")]
        public IActionResult getAllBookingByRoomID(int roomID)
        {
            var bookingList = _bookingService.getAllBookingByRoomID(roomID);
            if (bookingList == null)
            {
                return NotFound(NOT_FOUND);
            }
            return Ok(bookingList);
        }

        // Get Booking Details ( History)
        [HttpPost("/History/{roomID}")]
        [ActionName("Get Details of Booking")]
        public IActionResult getDetailsBookingByRoomID(int roomID)
        {
            var bookingDetails = _bookingService.getDetailsBooking(roomID);
            if ( bookingDetails.Count == 0)
            {
                return NotFound(NOT_FOUND); 
            }
            return Ok(bookingDetails);
        }
    }
}
