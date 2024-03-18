using BusinessObjects;
using BusinessObjects.Request;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class RoomRepository : IRoomRepository
    {
        private RoomDAO roomDAO;
        public RoomRepository()
        {
            roomDAO = new RoomDAO();
        }

        public List<Room> GetAllRoomById(int id) => roomDAO.GetAllRoomById(id);

        public Room getRoomById(int id) => roomDAO.getRoomById(id);

        public bool UpdateStatusRoom(Room room) => roomDAO.UpdateStatusRoom(room);

        public List<Room> GetRoomList() => roomDAO.GetRoomList();

        public RequestRoomDTO CreateNewRoom(RequestRoomDTO roomRequest) => roomDAO.CreateNewRoom(roomRequest);

        public bool UpdateRoom( RequestUpdateRoomDTO updatedRoom) => roomDAO.UpdateRoom( updatedRoom);

        public Room SearchRoom(string context) => roomDAO.SearchRoom(context);

        public Room GetRoomById(int id) => roomDAO.GetRoomById(id);
<<<<<<< HEAD
        public List<Room> SearchRoomByContext(string context) => roomDAO.SearchRoomByContext(context);
=======

        public Task<List<Room>> getActiveRoomList() => roomDAO.getActiveRoomList();
>>>>>>> Chuong_BackEnd
    }
}
