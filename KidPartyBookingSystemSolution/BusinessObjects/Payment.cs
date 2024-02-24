using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class Payment
    {
        public Payment()
        {
            TransactionBookings = new HashSet<TransactionBooking>();
        }

        public int PaymentId { get; set; }
        public string PaymentMethod { get; set; }
        public double Amount { get; set; }
        public DateTime CreateTime { get; set; }
        public int PaymentStatus { get; set; }

        public virtual ICollection<TransactionBooking> TransactionBookings { get; set; }
    }
}
