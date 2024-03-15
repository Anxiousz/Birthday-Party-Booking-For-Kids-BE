using AutoMapper;
using BusinessObjects;
using BusinessObjects.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class BookingDAO
    {
        private static BookingDAO instance = null;
        private readonly PHSContext dbContext = null;
        public BookingDAO()
        {
            if (dbContext == null)
            {
                dbContext = new PHSContext();
            }
        }

        public static BookingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BookingDAO();
                }
                return instance;
            }
        }

        // View Detail Booking 
        public List<Booking> getAllBookingByRoomID(int roomID)
        {
            try
            {
                 return dbContext.Bookings.Where( b => b.RoomId == roomID ).ToList();   
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // View Detail Booking 
        public List<RequestBookingPartyHostDTO> getDetailsBooking(int roomID)
        {
            try
            {
                var bookingDetail = dbContext.Bookings
                    .Include(b => b.MenuOrder)
                    .Include ( b => b.MenuOrder.FoodOrder)
                    .Include(b => b.Transaction)
                    .Include (b =>b.Transaction.Payment)
                    .Include(b => b.Acc)
                    .Include (b => b.Room)
                    .Where(b => b.RoomId == roomID)
                    .Select(b => new RequestBookingPartyHostDTO
                    {
                        BookingDate = b.BookingDate,
                        BookingStatus = b.BookingStatus,
                        Email = b.Acc.Email,
                        Phone = b.Acc.Phone,
                        BirthDay = b.Acc.BirthDay,
                        Gender = b.Acc.Gender,
                        Address = b.Acc.Address,
                        RoomName = b.Room.RoomName,
                        Price = b.Room.Price,
                        FoodName = b.MenuOrder.FoodOrder.FoodName,
                        Description = b.MenuOrder.FoodOrder.Description,
                        Quantity = b.MenuOrder.Quantity,
                        PaymentMethod = b.Transaction.Payment.PaymentMethod,
                        PaymentStatus = b.Transaction.Payment.PaymentStatus,                
                        CreateTime = b.Transaction.Payment.CreateTime,
                        TotalPrice = b.MenuOrder.TotalPrice
                    }) 
                    .ToList();
                return bookingDetail;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Booking> GetOrders()
        {
            return dbContext.Bookings.ToList();
        }

        public void createBooking(Booking newBooking)
        {   
            Booking booking = null;
            try
            {
                booking = new Booking()
                {
                    RoomId = newBooking.RoomId,
                    AccId = newBooking.AccId,
                    MenuOrderId = newBooking.MenuOrderId,
                    TransactionId = newBooking.TransactionId,
                    BookingDate = DateTime.Now,
                    BookingStatus = 0
                };
                dbContext.Bookings.Add(booking);
                dbContext.SaveChanges();
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Booking CreatBooking(RequestBookingDTO request)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            IMapper mapper = config.CreateMapper();
            Booking booking = mapper.Map<Booking>(request);
            dbContext.Bookings.Add(booking);
            dbContext.SaveChanges();
            return booking;
        }
    }
}
