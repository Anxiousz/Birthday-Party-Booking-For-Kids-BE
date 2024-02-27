using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TransactionBookingDAO
    {
        private static TransactionBookingDAO instance = null;
        private readonly PHSContext dbContext = null;
        public TransactionBookingDAO()
        {
            if (dbContext == null)
            {
                dbContext = new PHSContext();
            }
        }

        public static TransactionBookingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TransactionBookingDAO();
                }
                return instance;
            }
        }
    }
}
