using AutoMapper;
using Azure.Core;
using BusinessObjects;
using BusinessObjects.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class RoomDAO
    {
        private static RoomDAO instance = null;
        private readonly PHSContext dbContext = null;
        public RoomDAO()
        {
            if (dbContext == null)
            {
                dbContext = new PHSContext();
            }
        }

        public static RoomDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoomDAO();
                }
                return instance;
            }
        }

        // Get Room By Party Host ID
        public List<Room> GetAllRoomById(int id)
        {
            try
            {
                return dbContext.Rooms.Where(r => r.PartyHostId == id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Get Room by ID
        public Room getRoomById(int id)
        {
            try
            {
                return dbContext.Rooms.SingleOrDefault(r => r.RoomId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Create Room By Id 
        public RequestRoomDTO CreateNewRoom(RequestRoomDTO roomRequest)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<MappingProfile>();
                });
                IMapper mapper = config.CreateMapper();
                Room room = mapper.Map<Room>(roomRequest);
                if (dbContext.PartyHosts.Any(p => p.PartyHostId == room.PartyHostId))
                {
                    room.Status = 1;
                    dbContext.Rooms.Add(room);
                    dbContext.SaveChanges();
                    return roomRequest;
                }
                else
                {
                    throw new Exception("Giá trị 'PartyHostId' không hợp lệ.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update Status Room
        public void UpdateStatusRoom(Room room)
        {
            try
            {
                if (room.Status == 0)
                {
                    room.Status = 1;
                }
                else if (room.Status == 1)
                {
                    room.Status = 0;
                }
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update Room
        public bool UpdateRoom(RequestUpdateRoomDTO updatedRoom)
        {
            bool result = false;
            try
            {

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<MappingProfile>();
                });
                IMapper mapper = config.CreateMapper();
                Room updatedRoomEntity = mapper.Map<Room>(updatedRoom);

                //    var exsitingRoom = dbContext.Rooms.FirstOrDefault(f => f.PartyHostId == updatedRoomEntity.PartyHostId);
                var exsitingRoom = dbContext.Set<Room>().Local.FirstOrDefault(e => e.PartyHostId == updatedRoomEntity.PartyHostId);

                if (exsitingRoom != null)
                {
                    dbContext.Entry(exsitingRoom).State = EntityState.Detached;
                }
                dbContext.Entry(updatedRoomEntity).State = EntityState.Modified;
                dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        // List All Room 
        public List<Room> GetRoomList()
        {
            List<Room> roomList = null;
            try
            {
                roomList = dbContext.Rooms.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return roomList;
        }

        // SearchRoom
        public Room SearchRoom(string context)
        {
            Room room = null;
            try
            {

                room = dbContext.Rooms.FirstOrDefault(r => r.RoomName.Equals(context));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return room;
        }

        public Room GetRoomById(int id)
        {
            return dbContext.Rooms.FirstOrDefault(room => room.RoomId == id);
        }

        public List<Room> SearchRoomByContext(string context)
        {
            List<Room> roomList = null;
            try
            {
                roomList = dbContext.Rooms.Where(r => r.RoomName.Contains(context) || r.RoomType.Contains(context) || r.Location.Contains(context)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return roomList;
        }
    }
}
