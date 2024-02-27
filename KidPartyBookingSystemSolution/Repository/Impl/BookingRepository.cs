using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class BookingRepository : IBookingRepository
    {
        private BookingDAO bookingDAO;
        public BookingRepository()
        {
            bookingDAO = new BookingDAO();
        }
    }
}
