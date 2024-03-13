using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class MenuPartyHostDAO
    {
        //private MenuOrderDAO menuOrderDAO = new MenuOrderDAO();
        private static MenuPartyHostDAO instance = null;
        private readonly PHSContext dbContext = null;
        public MenuPartyHostDAO()
        {
            if (dbContext == null)
            {
                dbContext = new PHSContext();
            }
        }

        public static MenuPartyHostDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MenuPartyHostDAO();
                }
                return instance;
            }
        }
        // Get Menu Party Host 
        public List<MenuPartyHost> getListMenuPartyHost(int?id)
        {
            try
            {
                return dbContext.MenuPartyHosts.Where(m => m.PartyHostId == id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Get Each food by id
        public MenuPartyHost getMenuPartyHostFoodById(int id)
        {
            try
            {
                return dbContext.MenuPartyHosts.SingleOrDefault(m => m.FoodOrderId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Create New Menu Party Host 
        public void createNewMenuPartyHost(MenuPartyHost foodMenu)
        {
            try
            {
                dbContext.MenuPartyHosts.Add(foodMenu);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update Menu Party Host
        public bool updateMenuPartyHost(int id, MenuPartyHost updatedMenuPartyHost)
        {
            bool result = false;
            MenuPartyHost food = getMenuPartyHostFoodById((int)id);
            /*if (menuOrderDAO.checkFoodInstance(id) == true)
            {
                food = new MenuPartyHost
                {
                    FoodName = updatedMenuPartyHost.FoodName,
                    Description = updatedMenuPartyHost.Description,
                    Price = updatedMenuPartyHost.Price,
                    Image = updatedMenuPartyHost.Image,
                };
                dbContext.Update(food);
                dbContext.SaveChanges();
                result = true;
            }*/
            return result;
        }

        // Update Delete Food By Party Host 
        public bool deleteMenuPartyHost(int id)
        {
            bool result = false;
            MenuPartyHost food = getMenuPartyHostFoodById(id);
            /*if(menuOrderDAO.checkFoodInstance(id) == true && food != null)
            {
                dbContext.Remove(food);
                dbContext.SaveChanges();
                result = true;
            }*/
            return false;
        }
    }
}
