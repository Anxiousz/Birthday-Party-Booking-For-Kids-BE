using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class MenuOrderDAO
    {
        private MenuPartyHostDAO hostDAO;
        private static MenuOrderDAO instance = null;
        private readonly PHSContext dbContext = null;
        public MenuOrderDAO()
        {
            if (dbContext == null)
            {
                dbContext = new PHSContext();
            }
            hostDAO = new MenuPartyHostDAO();
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
        // get Menu order 
        public MenuOrder getMenuOrder(int id)
        {
            try
            {
                return dbContext.MenuOrders.SingleOrDefault(m => m.MenuOrderId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        // Create Menu Order Empty
        public MenuOrder createMenuOrder()
        {
            MenuOrder order = null;
            try
            {
                order = new MenuOrder()
                {
                    FoodName = "Nothing",
                    Quantity = 0,
                    TotalPrice = 0,
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }


        // Update MenuOrder
        public void updateMenuOrder(int id, MenuOrder updateMenuOrder)
        {
            try
            {
                if(id != null)
                {
                    MenuOrder orderUpdate = getMenuOrder(id);
                    orderUpdate = new MenuOrder()
                    {
                        FoodName = updateMenuOrder.FoodOrder.FoodName,
                        Quantity = updateMenuOrder.Quantity,
                        TotalPrice = updateMenuOrder.TotalPrice,
                    };
                    dbContext.Update(orderUpdate);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }
    }
}
