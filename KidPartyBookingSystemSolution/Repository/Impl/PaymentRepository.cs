using BusinessObjects;
using BusinessObjects.Request;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class PaymentRepository : IPaymentRepository
    {
        private PaymentDAO paymentDAO;
        public PaymentRepository()
        {
            paymentDAO = new PaymentDAO();
        }

        public Payment createPayment(RequestCreatePaymentDTO payment)
        {
            return paymentDAO.createPayment(payment);
        }
    }
}
