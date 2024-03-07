using AutoMapper;
using BusinessObjects;
using BusinessObjects.Response;
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

        public async Task<ResponseTransactionDTO> GetTransactionById(int id)
        {
            try
            {
                var db = dbContext.TransactionBookings.ToList();
                TransactionBooking? transaction = db.SingleOrDefault(x => x.TransactionId == id);
                Payment? payment = dbContext.Payments.SingleOrDefault(x => x.PaymentId == id);

                transaction.Payment = payment;
                if (transaction == null)
                {
                    throw new Exception("Transaction isn't exist");
                }
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<MappingProfile>();
                });
                IMapper mapper = config.CreateMapper();
                ResponseTransactionDTO transactionDTO = mapper.Map<ResponseTransactionDTO>(transaction);
                return transactionDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetTransactionById Error: {ex.Message}");
                return null;
            }

        }
    }
}
