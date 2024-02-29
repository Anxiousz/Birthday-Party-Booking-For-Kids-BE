using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Request
{
    public class RequestBookingPartyHostDTO
    {
        public DateTime BookingDate { get; set; }
        public int BookingStatus { get; set; }
        public int MenuOrderId { get; set;}
        public int? TransactionId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDay { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string RoomName { get; set;}
        public string PaymentMethod { get; set; }
        public double Amount { get; set; }
        public DateTime CreateTime { get; set; }
        public int PaymentStatus { get; set; }
        public int Price { get; set; }
        public int TotalPrice { get; set; }
        public string FoodName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
