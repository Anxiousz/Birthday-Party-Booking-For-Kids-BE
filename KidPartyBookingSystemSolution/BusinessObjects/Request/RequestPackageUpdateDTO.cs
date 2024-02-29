using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Request
{
    public class RequestPackageUpdateDTO
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
