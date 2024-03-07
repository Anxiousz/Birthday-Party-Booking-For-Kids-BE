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
        Task<ResponseTransactionDTO> GetTransactionById(int id);
    }
}
