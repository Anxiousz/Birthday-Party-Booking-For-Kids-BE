using BusinessObjects;
using BusinessObjects.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IRoomRepository
    {
        public List<Room> GetAllRoomById(int id);
        public Room getRoomById(int id);
        public void UpdateStatusRoom(Room room);
        public bool UpdateRoom(RequestUpdateRoomDTO updatedRoom);
        public List<Room> GetRoomList();
        public RequestRoomDTO CreateNewRoom(RequestRoomDTO roomRequest);
        public Room SearchRoom(string context);
        public Room GetRoomById(int id);
        public List<Room> SearchRoomByContext(string context);
    }
}
