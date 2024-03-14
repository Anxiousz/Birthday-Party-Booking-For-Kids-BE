using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Request
{
    public class RequestCreatePaymentDTO
    {
        public string PaymentMethod { get; set; }
        public double Amount { get; set; }
        public DateTime CreateTime { get; set; }
        public int PaymentStatus { get; set; }
    }
}
