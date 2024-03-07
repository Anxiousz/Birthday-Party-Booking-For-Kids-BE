using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Request
{
    public class RequestFeedbackDTO
    {
        public int? PostId { get; set; }
        public string? Comment { get; set; }
        public int? Rating { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
