using BusinessObjects;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class MenuOrderRepository : IMenuOrderRepository
    {
        private MenuOrderDAO menuOrderDAO;
        public MenuOrderRepository()
        {
            menuOrderDAO = new MenuOrderDAO();
        }

        public MenuOrder createMenuOrder() => MenuOrderDAO.Instance.createMenuOrder();

        public MenuOrder getMenuOrder(int id) => MenuOrderDAO.Instance.getMenuOrder(id);

        public void updateMenuOrder(int id, MenuOrder updateMenuOrder) => MenuOrderDAO.Instance.updateMenuOrder(id, updateMenuOrder);
    }
}
