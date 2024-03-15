using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Request
{
    public class RequestBookingDTO
    {
        public int RoomId { get; set; }
        public int AccId { get; set; }
        public int MenuOrderId { get; set; }
        public int? TransactionId { get; set; }
        public DateTime BookingDate { get; set; }
        public int BookingStatus { get; set; }
    }
}
