using Repository.Impl;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Response;
using BusinessObjects;
using BusinessObjects.Request;

namespace Services.Impl
{
    public class TransactionBookingService : ITransactionBookingService
    {
        private ITransactionBookingRepository transactionBookingRepository;

        public TransactionBookingService()
        {
            transactionBookingRepository = new TransactionBookingRepository();
        }

        public Task<ResponseTransactionDTO> GetTransactionById(int id) => transactionBookingRepository.GetTransactionById(id);

        public TransactionBooking CreateTransactionBooking(RequestCreateTransactionBookingDTO transactionBooking) => transactionBookingRepository.CreateTransactionBooking(transactionBooking);

    }
}
