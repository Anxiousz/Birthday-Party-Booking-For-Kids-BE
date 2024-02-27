using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class MenuOrder
    {
        public MenuOrder()
        {
            Bookings = new HashSet<Booking>();
        }

        public int MenuOrderId { get; set; }
        public int? FoodOrderId { get; set; }
        public string FoodName { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }

        public virtual MenuPartyHost FoodOrder { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
