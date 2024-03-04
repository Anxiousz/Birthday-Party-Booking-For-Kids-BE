using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects.Request
{
    public class RequestVoucherDTO
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int Expired { get; set; }
        public int? ReissuedBy { get; set; }
    }
}
