using Repository.Impl;
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
    public class RoomService : IRoomService
    {
        private IRoomRepository roomRepository;

        public RoomService()
        {
            roomRepository = new RoomRepository();
        }

        public List<Room> GetAllRoomById(int id) => roomRepository.GetAllRoomById(id);  

        public Room getRoomById(int id) => roomRepository.getRoomById(id);

        public void UpdateStatusRoom(Room room) => roomRepository.UpdateStatusRoom(room);
        
        public List<Room> GetRoomList() => roomRepository.GetRoomList();

        public RequestRoomDTO CreateNewRoom(RequestRoomDTO roomRequest) => roomRepository.CreateNewRoom(roomRequest);

        public bool UpdateRoom( RequestUpdateRoomDTO updatedRoom) => roomRepository.UpdateRoom( updatedRoom);

        public Room SearchRoom(string context) => roomRepository.SearchRoom(context);

        public Room GetRoomById(int id) => roomRepository.GetRoomById(id);
    }
}
