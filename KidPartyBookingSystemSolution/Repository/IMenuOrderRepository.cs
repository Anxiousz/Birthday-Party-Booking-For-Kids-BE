using BusinessObjects;
using BusinessObjects.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IMenuOrderRepository
    {
        public MenuOrder getMenuOrder(int id);
        public MenuOrder createMenuOrder();
        public void updateMenuOrder(int id, MenuOrder updateMenuOrder);
        public MenuOrder createMenuOrderFull(RequestMenuOrderDTO order);
        public MenuOrder UpdateMenuOrder(RequestUpdateMenuOrderDTO order);
        public bool DeleteMenuOrder(int id);
    }
}
