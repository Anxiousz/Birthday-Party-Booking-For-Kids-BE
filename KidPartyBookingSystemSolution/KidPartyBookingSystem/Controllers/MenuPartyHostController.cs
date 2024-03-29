﻿using Azure.Core;
using BusinessObjects;
using BusinessObjects.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace KidPartyBookingSystem.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class MenuPartyHostController : ControllerBase
    {
        private static String NOT_FOUND = "Hien tai khong tim thay du lieu";
        private IMenuPartyHostService _menuPartyHostService;
        private IConfiguration _config;
        public MenuPartyHostController(IMenuPartyHostService menuPartyHostService, IConfiguration config)
        {
            _menuPartyHostService = menuPartyHostService;
            _config = config;
        }

        // Get Menu Party Host
        [HttpGet("PartyHostId")]
        public IActionResult GetMenuPartyHost(int? partyHostid)
        {
            var menuPartyHost = _menuPartyHostService.getListMenuPartyHost(partyHostid);
            if (menuPartyHost == null)
            {
                return NotFound(NOT_FOUND);
            }
            return Ok(menuPartyHost);
        }

        [HttpGet("GetOneFood/{id}")]
        [Authorize(Roles = "3")]
        public IActionResult GetMenuFoodById(int id)
        {
            var food = _menuPartyHostService.getMenuPartyHostFoodById(id);
            if (food == null)
            {
                return NotFound(NOT_FOUND);
            }
            return Ok(food);
        }

        // Create Menu Party Host
        [HttpPost("CreateMenuPartyHost")]
        [Authorize(Roles ="3")]
        public IActionResult CreateMenuFood([FromBody] RequestMenuPartyHostDTO menu)
        {
            if (menu == null)
            {
                return BadRequest("Fill Full empty fields please!!");
            }
            else
            {
                _menuPartyHostService.createNewMenuPartyHost(menu);
                return Ok(menu);
            }
        }

        // Update Menu Party Host
        [HttpPost("UpdateMenuPartyHostV2")]
        [Authorize(Roles = "3")]
        public IActionResult UpdateMenuFoodV2([FromBody] RequestUpdateMenuPartyHostDTO menu)
        {
            if (menu == null)
            {
                return BadRequest("Fill Full empty fields please!!");
            }
            else
            {
                if (_menuPartyHostService.updateMenuPartyHostv2(menu) == true)
                {
                    return Ok(menu);
                }
                else
                {
                    return BadRequest("Update failed");
                }
                
            }
        }


        // Get All Menu Party Host 
        [HttpGet("GetAllMenuPartyHost")]
        [Authorize(Roles = "3")]
        public IActionResult GetAllMenuPartyHost()
        {
            List<MenuPartyHost> list = null; 
            list = _menuPartyHostService.getMenuPartyHosts();
            if (list == null)
            {
                return NotFound("Khong timf thay bat cu san pham nao!");
            }
            else
            {
                return Ok(list);
            }
        }


        //Delete Food V2
        [HttpDelete("DeleteV2/{id}")]
        [Authorize(Roles = "3")]
        public IActionResult DeleteMenuFoodByIdV2(int id)
        {
            if (_menuPartyHostService.deleteFoodV2(id) == true)
            {
                return Ok("Successfully");
            }
            else
            {
                return BadRequest("Hien tai khong the xoa duoc mon an nay");
            }
        }


        // Get All Food List 
        [HttpGet("GetAllFoodByAdmin")]
        [Authorize(Roles = "1")]
        public IActionResult getAllFoodList()
        {
            List<MenuPartyHost> list = null;
            list = _menuPartyHostService.getMenuPartyHosts();
            if(list.Count == 0)
            {
                return BadRequest("Not found any");
            }
            else
            {
                return Ok(list);
            }
        }
    }
}

