using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class MenuOrder
    {
        public int MenuId { get; set; }
        public int? FoodOrderId { get; set; }
        public int? BookingId { get; set; }
        public int? RoomId { get; set; }
        public int? AccId { get; set; }
        public string FoodName { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
