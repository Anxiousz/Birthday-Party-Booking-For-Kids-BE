using AutoMapper;
using BusinessObjects;
using BusinessObjects.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PaymentDAO
    {
        private static PaymentDAO instance = null;
        private readonly PHSContext dbContext = null;
        public PaymentDAO()
        {
            if (dbContext == null)
            {
                dbContext = new PHSContext();
            }
        }

        public static PaymentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PaymentDAO();
                }
                return instance;
            }
        }

        public Payment createPayment(RequestCreatePaymentDTO payment)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            IMapper mapper = config.CreateMapper();
            Payment addPayment = mapper.Map<Payment>(payment);
            dbContext.Payments.Add(addPayment);
            dbContext.SaveChanges();
            return addPayment;
        }
    }
}
