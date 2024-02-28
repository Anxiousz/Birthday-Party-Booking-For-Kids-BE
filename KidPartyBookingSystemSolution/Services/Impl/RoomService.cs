using Repository.Impl;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Services.Impl
{
    public class RoomService : IRoomService
    {
        private IRoomRepository roomRepository;

        public RoomService()
        {
            roomRepository = new RoomRepository();
        }

        public void CreateNewRoom(Room room) => roomRepository.CreateNewRoom(room);

        public List<Room> GetAllRoomById(int id) => roomRepository.GetAllRoomById(id);  

        public Room getRoomById(int id) => roomRepository.getRoomById(id);

        public bool UpdateRoom(int id, Room updatedRoom) => roomRepository.UpdateRoom(id, updatedRoom);

        public void UpdateStatusRoom(Room room) => roomRepository.UpdateStatusRoom(room);
    }
}
