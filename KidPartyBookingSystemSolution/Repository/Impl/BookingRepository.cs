using BusinessObjects;
using BusinessObjects.Request;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class BookingRepository : IBookingRepository
    {
        private BookingDAO bookingDAO;
        public BookingRepository()
        {
            bookingDAO = new BookingDAO();
        }

        public List<Booking> getAllBookingByRoomID(int roomID) => bookingDAO.getAllBookingByRoomID(roomID);

        public List<RequestBookingPartyHostDTO> getDetailsBooking(int roomID) => bookingDAO.getDetailsBooking(roomID);
        public List<Booking> GetOrders() => bookingDAO.GetOrders();
    }
}
