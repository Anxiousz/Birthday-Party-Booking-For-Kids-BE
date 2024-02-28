using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace KidPartyBookingSystem.Controllers
{
    [ApiController]
    [Route("v1/api/[Controller]")]
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
        [HttpGet("{id}")]
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
        [HttpPost("{id}")]
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
        [HttpPut("{id}")]
        [ActionName("UpdateRoom")]
        public IActionResult UpdateRoom(int id, [FromBody] Room updateRoom)
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
                    return Ok();
                }
                return BadRequest("Chua the update phong");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occured:{ex.Message}");
            }
        }
    }
}
