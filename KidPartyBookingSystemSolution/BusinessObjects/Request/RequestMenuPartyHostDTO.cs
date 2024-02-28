using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Request
{
    public class RequestMenuPartyHostDTO
    {
        public int FoodOrderId { get; set; }
        public string FoodName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int? PartyHostId { get; set; }
        public string Image { get; set; }
    }
}
