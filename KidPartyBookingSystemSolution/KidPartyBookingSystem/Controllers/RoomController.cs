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
        [Authorize(Roles = "3")]
        public IActionResult UpdateStatus(int id)
        {
            var room = _roomService.getRoomById(id);
            if (room == null)
            {
                return NotFound();
            }
            else
            {
                if( _roomService.UpdateStatusRoom(room) == true)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Room is not valid to Block");
                }
                
            }
        }

        // Update Room By ID
        [HttpPost("UpdateRoom")]
        [ActionName("UpdateRoom")]
        [Authorize(Roles = "3")]
        public IActionResult UpdateRoom( [FromBody] RequestUpdateRoomDTO updateRoom)
        {
            var room = _roomService.getRoomById(updateRoom.RoomId);
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
                if (_roomService.UpdateRoom( updateRoom) == true)
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
        [HttpGet("GetAllRoomAdmin")]
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
        [Authorize(Roles = "3")]
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

        // Get Room By id 
        [HttpGet("/RoomDetails/roomID")]
        public IActionResult GetRoomDetails(int id)
        {
            var roomDetails = _roomService.GetAllRoomById(id);
            if (roomDetails == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(roomDetails);
            }
        }

        // Search Room 
        [HttpPost("/SearchRoom/roomName")]
        public IActionResult SearchRoomByName(string context)
        {
            var room = _roomService.SearchRoom(context);
            if (room != null)
            {
                return Ok(room);
            } else
            {
                return NotFound();
            }
        }

        // Get Room Details
        [HttpGet("GetRoomDetails/roomID")]
        public IActionResult GetRoomByID(int id)
        {
            var roomDetails = _roomService.GetRoomById(id);
            if (roomDetails == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(roomDetails);
            }
        }

        // Get Room For User Home Page
        [HttpGet("GetRoomHomePage")]
        public async Task<IActionResult> GetAllRoomUserPage()
        {
            List<Room> roomList = await _roomService.getActiveRoomList();
            if(roomList.Count > 0)
            {
                return Ok(roomList);
            }
            else
            {
                return NotFound("No Room available now!!");
            }
        }
    }
}
