using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class Config
    {
        public int ConfigId { get; set; }
        public int? AdminId { get; set; }
        public int NumberOfPage { get; set; }
        public int NumberOfPost { get; set; }
        public DateTime? DateTime { get; set; }

        public virtual Admin Admin { get; set; }
    }
}
