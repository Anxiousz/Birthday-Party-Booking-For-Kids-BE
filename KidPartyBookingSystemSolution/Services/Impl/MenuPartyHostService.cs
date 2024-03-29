﻿using Repository.Impl;
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
    public class MenuPartyHostService : IMenuPartyHostService
    {
        private IMenuPartyHostRepository menuPartyHostRepository;

        public MenuPartyHostService()
        {
            menuPartyHostRepository = new MenuPartyHostRepository();
        }

        public void createNewMenuPartyHost(MenuPartyHost foodMenu) => menuPartyHostRepository.createNewMenuPartyHost(foodMenu);


        //public bool deleteMenuPartyHost(int id) => menuPartyHostRepository.deleteMenuPartyHost(id);

        public List<MenuPartyHost> getListMenuPartyHost(int?id) => menuPartyHostRepository.getListMenuPartyHost(id);

        public MenuPartyHost getMenuPartyHostFoodById(int id) => menuPartyHostRepository.getMenuPartyHostFoodById((int)id);

        //public bool updateMenuPartyHost(int id, MenuPartyHost updatedMenuPartyHost) => menuPartyHostRepository.updateMenuPartyHost(id, updatedMenuPartyHost);

        public bool updateMenuPartyHostv2(RequestUpdateMenuPartyHostDTO requestFoodUpdate) => menuPartyHostRepository.updateMenuPartyHostv2(requestFoodUpdate);

        public RequestMenuPartyHostDTO createNewMenuPartyHost(RequestMenuPartyHostDTO food) => menuPartyHostRepository.createNewMenuPartyHost(food);

        public List<MenuPartyHost> getMenuPartyHosts() => menuPartyHostRepository.getMenuPartyHosts();

        public bool deleteFoodV2(int id) => menuPartyHostRepository.deleteFoodV2((int)id);
    }
}
