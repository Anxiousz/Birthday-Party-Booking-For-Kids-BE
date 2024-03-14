using BusinessObjects;
using BusinessObjects.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IRoomService
    {
        public List<Room> GetAllRoomById(int id);
        public Room getRoomById(int id);
        public RequestRoomDTO CreateNewRoom(RequestRoomDTO roomRequest);
        public void UpdateStatusRoom(Room room);
        public bool UpdateRoom(int id, RequestRoomDTO updatedRoom);
        public List<Room> GetRoomList();
        public Room SearchRoom(string context);
        public Room GetRoomById(int id);
    }
}
