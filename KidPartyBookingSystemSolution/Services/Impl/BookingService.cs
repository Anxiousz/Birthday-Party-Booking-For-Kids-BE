using Repository.Impl;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using BusinessObjects.Request;

namespace Services.Impl
{
    public class BookingService : IBookingService
    {
        private IBookingRepository bookingRepository;

        public BookingService()
        {
            bookingRepository = new BookingRepository();
        }

        public List<Booking> getAllBookingByRoomID(int roomID) => bookingRepository.getAllBookingByRoomID(roomID);

        public List<RequestBookingPartyHostDTO> getDetailsBooking(int roomID) => bookingRepository.getDetailsBooking(roomID);
        public List<Booking> GetOrders() => bookingRepository.GetOrders();
    }
}
