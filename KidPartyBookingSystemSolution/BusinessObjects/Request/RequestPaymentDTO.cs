using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Request
{
    public class RequestPaymentDTO
    {
        public int RoomID { get; set; }
        public int MenuOrderID { get; set; }
        public int AccID { get; set; }
    }
}
