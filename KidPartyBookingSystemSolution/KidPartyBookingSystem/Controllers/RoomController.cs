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
    //[Authorize (Roles = "3")]
    public class RoomController : ControllerBase
    {
        private IConfiguration _config;
        private IRoomService _roomService;
        public RoomController(IConfiguration config, IRoomService roomService)
        {
            _config = config;
            _roomService = roomService;
        }

        // Get Room By ID ( Party host )
        [HttpGet("GetRoomPartyHost/{id}")]
        public IActionResult Get(int id)
        {
            var listRoom = _roomService.GetAllRoomById(id);
            if (listRoom == null)
            {
                return NotFound();
            }
            return Ok(listRoom);
        }

        // Update Status Room ID 
        [HttpPost("UpdateStatus/{id}")]
        [ActionName("UpdateStatusRoom")]
        public IActionResult UpdateStatus(int id)
        {
            var room = _roomService.getRoomById(id);
            if (room == null)
            {
                return NotFound();
            }
            else
            {
                _roomService.UpdateStatusRoom(room);
                return Ok();
            }
        }

        /*        // Remove Room By Room ID 
        [HttpDelete("{id}")]
        [ActionName("DeleteRoom")]
        public IActionResult DeleteRoom(int id)
        {
            var room = _roomService.GetRoomByID(id);
            if (room == null)
            {
                return NotFound();
            }
            try
            {
                if (_roomService.DeleteRoom(room) == true)
                {
                    return Ok();
                }
                return BadRequest("Khong the xoa phong khi phong dang hoat dong");    
            } catch(Exception ex)
            {
                return StatusCode(500, $"An error occured :{ex.Message}");
            }
        }*/

        // Update Room By ID
        [HttpPut("Update/{id}")]
        [ActionName("UpdateRoom")]
        public IActionResult UpdateRoom(int id, [FromBody] RequestRoomDTO updateRoom)
        {
            var room = _roomService.getRoomById(id);
            if (room == null)
            {
                return NotFound();
            }
            else if (room.Status == 0)
            {
                return BadRequest("Phong dang su dung khong the xoa");
            }
            try
            {
                if (!_roomService.UpdateRoom(id, updateRoom))
                {
                    return Ok("Update Successfully!");
                }
                return BadRequest("Chua the update phong");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occured:{ex.Message}");
            }
        }

        // Get All Room
        [HttpGet("GetAllRoom")]
        [ActionName("Get All Room")]
        [EnableCors]
        public IActionResult GetRoom()
        {
            var roomList = _roomService.GetRoomList();
            if (roomList == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(roomList);
            }
        }

        // Create New Room 
        [HttpPost("Create")]
        [ActionName("Create New Room")]
        public IActionResult CreateNewRoom([FromBody] RequestRoomDTO roomRequest)
        {
            try
            {
                if (roomRequest != null)
                {
                    _roomService.CreateNewRoom(roomRequest);
                    return Ok("Room Added Successfully!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return StatusCode(500, "You have some error! Please check it again");
        }
    }
}
