using BusinessObjects;
using BusinessObjects.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBookingRepository
    {
        public List<Booking> getAllBookingByRoomID(int roomID);
        public List<RequestBookingPartyHostDTO> getDetailsBooking(int roomID);
    }
}
