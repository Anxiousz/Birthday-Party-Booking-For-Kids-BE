using Repository.Impl;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Response;

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
    }
}
