using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class staff
    {
        public staff()
        {
            PartyHosts = new HashSet<PartyHost>();
        }

        public int StaffId { get; set; }
        public int? SuperiorId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime BirthDay { get; set; }
        public string Phone { get; set; }
        public bool? Gender { get; set; }
        public string Address { get; set; }
        public int? Status { get; set; }

        public virtual Admin Superior { get; set; }
        public virtual ICollection<PartyHost> PartyHosts { get; set; }
    }
}
