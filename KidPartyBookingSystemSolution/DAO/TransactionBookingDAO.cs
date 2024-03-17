using AutoMapper;
using BusinessObjects;
using BusinessObjects.Request;
using BusinessObjects.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
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

        public List<Booking> GetTransactionById(int id)
        {
            try
            {
                return dbContext.Bookings
                    .Include(x => x.Transaction)
                    .ThenInclude(x => x.Payment)
                    .Where(x => x.AccId == id)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetTransactionById Error: {ex.Message}");
                return null;
            }
        }

        public TransactionBooking CreateTransactionBooking(RequestCreateTransactionBookingDTO transaction)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            IMapper mapper = config.CreateMapper();
            TransactionBooking addTransaction = mapper.Map<TransactionBooking>(transaction);
            dbContext.TransactionBookings.Add(addTransaction);
            dbContext.SaveChanges();
            return addTransaction;
        }
    }
}
