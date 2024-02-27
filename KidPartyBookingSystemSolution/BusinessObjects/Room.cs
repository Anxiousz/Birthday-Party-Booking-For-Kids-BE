using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        public int RoomId { get; set; }
        public int? PartyHostId { get; set; }
        public string RoomName { get; set; }
        public string RoomType { get; set; }
        public int Capacity { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string Location { get; set; }
        public int Price { get; set; }
        public string Note { get; set; }
        public string Image { get; set; }
        public int Status { get; set; }

        public virtual PartyHost PartyHost { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
