using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class Post
    {
        public Post()
        {
            Feedbacks = new HashSet<Feedback>();
        }

        public int PostId { get; set; }
        public string Context { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public string Image { get; set; }

        public virtual PartyHost CreatedByNavigation { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
