using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class Package
    {
        public Package()
        {
            PartyHosts = new HashSet<PartyHost>();
        }

        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int? CreatedBy { get; set; }

        public virtual Admin CreatedByNavigation { get; set; }
        public virtual ICollection<PartyHost> PartyHosts { get; set; }
    }
}
