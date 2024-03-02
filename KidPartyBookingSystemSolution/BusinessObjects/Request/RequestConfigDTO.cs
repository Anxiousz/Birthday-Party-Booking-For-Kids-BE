using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Request
{
    public class RequestConfigDTO
    {
        public int? AdminId { get; set; }
        public int NumberOfPage { get; set; }
        public int NumberOfPost { get; set; }
    }
}
