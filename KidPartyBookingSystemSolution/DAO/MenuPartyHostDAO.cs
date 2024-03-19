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
    public class MenuPartyHostDAO
    {
        //private MenuOrderDAO menuOrderDAO;
        private static MenuPartyHostDAO instance;
        private readonly PHSContext dbContext;
        public MenuPartyHostDAO()
        {
            if (dbContext == null)
            {
                dbContext = new PHSContext();
            }

            //menuOrderDAO = new MenuOrderDAO();
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
        public List<MenuPartyHost> getListMenuPartyHost(int? id)
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

        // Delete Food By PartyHostV2 
        public bool deleteFoodV2(int id)
        {
            bool result = false;

            if( checkExistingFood(id) == true )
            {
                MenuPartyHost food = getMenuPartyHostFoodById(id);
                if (food != null)
                {
                    dbContext.Remove(food);
                    dbContext.SaveChanges();
                    result = true;
                }
            }
            else
            {
                result = false;
            }
           
            return result;
        }


        // Create Menu PartyHost Food 
        public RequestMenuPartyHostDTO createNewMenuPartyHost(RequestMenuPartyHostDTO food)
        {
            try
            {
                var config = new MapperConfiguration(cgf =>
                {
                    cgf.AddProfile<MappingProfile>();
                });
                IMapper mapper = config.CreateMapper();
                MenuPartyHost partyhostFood = mapper.Map<MenuPartyHost>(food);
                if (dbContext.PartyHosts.Any(p => p.PartyHostId == food.PartyHostId))
                {
                    dbContext.MenuPartyHosts.Add(partyhostFood);
                    dbContext.SaveChanges();
                    return food;
                }
                else
                {
                    throw new Exception("Partyhostid is invalid!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update Menu Party Host Food 
        public bool updateMenuPartyHostv2(RequestUpdateMenuPartyHostDTO requestFoodUpdate)
        {
            bool result = false;
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<MappingProfile>();
                });
                IMapper mapper = config.CreateMapper();
                MenuPartyHost partyhostFood = mapper.Map<MenuPartyHost>(requestFoodUpdate);
                if(checkExistingFood(partyhostFood.FoodOrderId) == true)
                {
                    var existingMenuPartyHost = dbContext.Set<MenuPartyHost>().Local.FirstOrDefault(e => e.PartyHostId == partyhostFood.PartyHostId);

                    if (existingMenuPartyHost != null)
                    {
                        dbContext.Entry(existingMenuPartyHost).State = EntityState.Detached;
                    }
                    dbContext.Entry(partyhostFood).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        // Get All Food 
        public List<MenuPartyHost> getMenuPartyHosts()
        {
            List<MenuPartyHost> foodList = null;
            try
            {
                foodList = dbContext.MenuPartyHosts
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return foodList;
        }

        // Check existing Food Booked
        public bool checkExistingFood(int id)
        {
            bool result = false;
            try
            {
                Booking booking = dbContext.Bookings
                                    .Include(b => b.MenuOrder)
                                    .Where(b => b.MenuOrder.FoodOrderId == id)
                                    .FirstOrDefault(b => b.BookingStatus == 1);
                if (booking != null)
                {
                    result = false;
                }
                else
                {
                    result = true;
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
