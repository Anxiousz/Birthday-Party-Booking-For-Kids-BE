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
    public class MenuPartyHostRepository : IMenuPartyHostRepository
    {
        private MenuPartyHostDAO menuPartyHostDAO;
        public MenuPartyHostRepository()
        {
            menuPartyHostDAO = new MenuPartyHostDAO();
        }

        public void createNewMenuPartyHost(MenuPartyHost foodMenu) => menuPartyHostDAO.createNewMenuPartyHost(foodMenu);



        public bool deleteMenuPartyHost(int id) => menuPartyHostDAO.deleteMenuPartyHost(id);

        public List<MenuPartyHost> getListMenuPartyHost(int?id) => menuPartyHostDAO.getListMenuPartyHost(id);

        public MenuPartyHost getMenuPartyHostFoodById(int id) => menuPartyHostDAO.getMenuPartyHostFoodById((int)id);

        public bool updateMenuPartyHost(int id, MenuPartyHost updatedMenuPartyHost) => menuPartyHostDAO.updateMenuPartyHost(id, updatedMenuPartyHost);

        public bool updateMenuPartyHostv2(RequestUpdateMenuPartyHostDTO requestFoodUpdate) => menuPartyHostDAO.updateMenuPartyHostv2(requestFoodUpdate);

        public RequestMenuPartyHostDTO createNewMenuPartyHost(RequestMenuPartyHostDTO food) => menuPartyHostDAO.createNewMenuPartyHost(food);
    }
}
