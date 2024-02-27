using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class TransactionBookingRepository : ITransactionBookingRepository
    {
        private TransactionBookingDAO transactionBookingDAO;
        public TransactionBookingRepository()
        {
            transactionBookingDAO = new TransactionBookingDAO();
        }
    }
}
