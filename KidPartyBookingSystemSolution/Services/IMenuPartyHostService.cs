using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IMenuPartyHostService
    {
        public List<MenuPartyHost> getListMenuPartyHost(int?id);
        public MenuPartyHost getMenuPartyHostFoodById(int id);
        public void createNewMenuPartyHost(MenuPartyHost foodMenu);
        public bool updateMenuPartyHost(int id, MenuPartyHost updatedMenuPartyHost);
        public bool deleteMenuPartyHost(int id);
    }
}
