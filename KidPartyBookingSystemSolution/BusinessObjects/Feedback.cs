using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public int? PostId { get; set; }
        public string Comment { get; set; }
        public int? Rating { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual RegisteredUser CreatedByNavigation { get; set; }
        public virtual Post Post { get; set; }
    }
}
