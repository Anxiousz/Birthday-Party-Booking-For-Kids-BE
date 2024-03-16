using Repository.Impl;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using BusinessObjects.Request;

namespace Services.Impl
{
    public class MenuOrderService : IMenuOrderService
    {
        private IMenuOrderRepository menuOrderRepository;

        public MenuOrderService()
        {
            menuOrderRepository = new MenuOrderRepository();
        }

        public MenuOrder createMenuOrder() => menuOrderRepository.createMenuOrder();

        public MenuOrder getMenuOrder(int id) => menuOrderRepository.getMenuOrder(id);

        public void updateMenuOrder(int id, MenuOrder updateMenuOrder) => menuOrderRepository.updateMenuOrder(id, updateMenuOrder);

        public MenuOrder createMenuOrderFull(RequestMenuOrderDTO order) => menuOrderRepository.createMenuOrderFull(order);

        public MenuOrder UpdateMenuOrder(RequestUpdateMenuOrderDTO order) => menuOrderRepository.UpdateMenuOrder(order);

        public bool DeleteMenuOrder(int id) => menuOrderRepository.DeleteMenuOrder(id);
    }
}
