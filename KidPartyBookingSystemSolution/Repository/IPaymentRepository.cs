using BusinessObjects;
using BusinessObjects.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IPaymentRepository
    {
        public Payment createPayment(RequestCreatePaymentDTO payment);
    }
}
