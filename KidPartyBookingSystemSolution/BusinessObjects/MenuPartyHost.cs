using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class MenuPartyHost
    {
        public MenuPartyHost()
        {
            MenuOrders = new HashSet<MenuOrder>();
        }

        public int FoodOrderId { get; set; }
        public string FoodName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int? PartyHostId { get; set; }
        public string Image { get; set; }

        public virtual PartyHost PartyHost { get; set; }
        public virtual ICollection<MenuOrder> MenuOrders { get; set; }
    }
}
