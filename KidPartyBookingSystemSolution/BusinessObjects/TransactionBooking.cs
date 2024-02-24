using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class TransactionBooking
    {
        public int TransactionId { get; set; }
        public int? BookingId { get; set; }
        public int? RoomId { get; set; }
        public int? AccId { get; set; }
        public int? PaymentId { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
