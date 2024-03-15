using BusinessObjects;
using BusinessObjects.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBookingService
    {
        public List<Booking> getAllBookingByRoomID(int roomID);
        public List<RequestBookingPartyHostDTO> getDetailsBooking(int roomID);
        public List<Booking> GetOrders();
        public Booking CreatBooking(RequestBookingDTO request);
    }
}
