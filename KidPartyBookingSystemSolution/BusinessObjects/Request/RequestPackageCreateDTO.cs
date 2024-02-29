using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Request
{
    public class RequestPackageCreateDTO
    {
        public string PackageName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int? CreatedBy { get; set; }
    }
}
