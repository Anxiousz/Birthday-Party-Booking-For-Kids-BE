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

        public MenuOrder createMenuOrderFull(RequestMenuOrderDTO order) => MenuOrderDAO.Instance.createMenuOrderFull(order);

        public MenuOrder UpdateMenuOrder(RequestUpdateMenuOrderDTO order) => MenuOrderDAO.Instance.UpdateMenuOrder(order);

        public bool DeleteMenuOrder(int id) => MenuOrderDAO.Instance.DeleteMenuOrder(id);
    }

}
