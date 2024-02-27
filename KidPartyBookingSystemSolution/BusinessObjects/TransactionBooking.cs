using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class TransactionBooking
    {
        public TransactionBooking()
        {
            Bookings = new HashSet<Booking>();
        }

        public int TransactionId { get; set; }
        public int? PaymentId { get; set; }

        public virtual Payment Payment { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
