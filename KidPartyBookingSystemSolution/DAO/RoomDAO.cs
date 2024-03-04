using BusinessObjects;
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
        public void CreateNewRoom(Room room)
        {
            try
            {
                dbContext.Rooms.Add(room);
                dbContext.SaveChanges();
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
                if(room.Status == 0)
                {
                    room.Status = 1;
                } else if (room.Status == 1)
                {
                    room.Status = 0;
                }
                dbContext.SaveChanges();
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Update Room
        public bool UpdateRoom(int id, Room updatedRoom)
        {
            bool result = false;
            Room room = getRoomById(id);
            try
            {
                if (room != null)
                {
                    room = new Room
                    {
                        PartyHostId = room.PartyHostId,
                        RoomName = updatedRoom.RoomName,
                        RoomType = room.RoomType,
                        Capacity = updatedRoom.Capacity,
                        TimeStart = updatedRoom.TimeStart,
                        TimeEnd = updatedRoom.TimeEnd,
                        Location = updatedRoom.Location,
                        Price = updatedRoom.Price,
                        Note = updatedRoom.Note,
                        Status = 0
                    };
                    dbContext.Update(room);
                    dbContext.SaveChanges();
                    return result = true;
                }
            } catch (Exception ex)
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
    }
}
