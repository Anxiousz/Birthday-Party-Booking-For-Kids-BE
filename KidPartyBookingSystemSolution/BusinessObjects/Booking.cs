using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public int AccId { get; set; }
        public int MenuOrderId { get; set; }
        public int? TransactionId { get; set; }
        public DateTime BookingDate { get; set; }
        public int BookingStatus { get; set; }

        public virtual RegisteredUser Acc { get; set; }
        public virtual MenuOrder MenuOrder { get; set; }
        public virtual Room Room { get; set; }
        public virtual TransactionBooking Transaction { get; set; }
    }
}
