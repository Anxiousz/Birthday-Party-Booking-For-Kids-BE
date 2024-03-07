using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IMenuOrderService
    {
        public MenuOrder getMenuOrder(int id);
        public MenuOrder createMenuOrder();
        public void updateMenuOrder(int id, MenuOrder updateMenuOrder);
    }
}
