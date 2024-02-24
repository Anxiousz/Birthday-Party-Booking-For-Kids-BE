using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class LogAction
    {
        public int LogId { get; set; }
        public int? AccId { get; set; }
        public string ActionType { get; set; }
        public DateTime? Date { get; set; }
    }
}
