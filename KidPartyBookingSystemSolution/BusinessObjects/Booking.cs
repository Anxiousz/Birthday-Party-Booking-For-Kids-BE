using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class Booking
    {
        public Booking()
        {
            MenuOrders = new HashSet<MenuOrder>();
            TransactionBookings = new HashSet<TransactionBooking>();
        }

        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public int AccId { get; set; }
        public DateTime BookingDate { get; set; }
        public int BookingStatus { get; set; }

        public virtual RegisteredUser Acc { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<MenuOrder> MenuOrders { get; set; }
        public virtual ICollection<TransactionBooking> TransactionBookings { get; set; }
    }
}
