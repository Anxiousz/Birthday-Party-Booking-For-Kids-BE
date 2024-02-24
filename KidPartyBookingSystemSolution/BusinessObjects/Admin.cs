using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class Admin
    {
        public Admin()
        {
            Configs = new HashSet<Config>();
            Packages = new HashSet<Package>();
            staff = new HashSet<staff>();
        }

        public int AdminId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Config> Configs { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
        public virtual ICollection<staff> staff { get; set; }
    }
}
