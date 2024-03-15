using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Request
{
    public class RequestPaymentDTO
    {
        public int FoodOrderId { get; set; }
        public int Quantity { get; set; }
        public int RoomID { get; set; }
        public int AccID { get; set; }
    }
}
