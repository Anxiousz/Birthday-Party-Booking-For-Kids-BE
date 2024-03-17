using BusinessObjects;
using BusinessObjects.Request;
using BusinessObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ITransactionBookingService
    {
        public List<Booking> GetTransactionById(int id);
        public TransactionBooking CreateTransactionBooking(RequestCreateTransactionBookingDTO transactionBooking);
    }
}
