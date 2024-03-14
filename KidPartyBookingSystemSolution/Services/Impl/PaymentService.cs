using Repository.Impl;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using BusinessObjects.Request;

namespace Services.Impl
{
    public class PaymentService : IPaymentService
    {
        private IPaymentRepository paymentRepository;

        public PaymentService()
        {
            paymentRepository = new PaymentRepository();
        }

        public Payment createPayment(RequestCreatePaymentDTO payment)
        {
            return paymentRepository.createPayment(payment);
        }
    }
}
