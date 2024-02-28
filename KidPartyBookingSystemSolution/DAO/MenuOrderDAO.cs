using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class MenuOrderDAO
    {
        private static MenuOrderDAO instance = null;
        private readonly PHSContext dbContext = null;
        public MenuOrderDAO()
        {
            if (dbContext == null)
            {
                dbContext = new PHSContext();
            }
        }

        public static MenuOrderDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MenuOrderDAO();
                }
                return instance;
            }
        }



        // Check Menu Party Host (
        public bool checkFoodInstance(int id)
        {   
            bool result = false;
            MenuOrder order = null;
            try
            {
                order = dbContext.MenuOrders
                    .Include(m => m.Bookings)
                    .FirstOrDefault(m => m.FoodOrderId == id && m.Bookings.Any(b => b.BookingStatus == 1));
                if (order == null)
                {
                    return true;  
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
