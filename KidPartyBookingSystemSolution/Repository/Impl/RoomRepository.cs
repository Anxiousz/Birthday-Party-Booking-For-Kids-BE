using BusinessObjects;
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

        public void CreateNewRoom(Room room) => roomDAO.CreateNewRoom(room);

        public List<Room> GetAllRoomById(int id) => roomDAO.GetAllRoomById(id);

        public Room getRoomById(int id) => roomDAO.getRoomById(id);

        public bool UpdateRoom(int id, Room updatedRoom) => roomDAO.UpdateRoom(id, updatedRoom);

        public void UpdateStatusRoom(Room room) => roomDAO.UpdateStatusRoom(room);
    }
}
