using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class Voucher
    {
        public int VoucherId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int Expired { get; set; }
        public int? ReissuedBy { get; set; }

        public virtual PartyHost ReissuedByNavigation { get; set; }
    }
}
