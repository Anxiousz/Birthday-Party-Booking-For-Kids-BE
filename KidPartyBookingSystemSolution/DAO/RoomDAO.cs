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
        public bool UpdateStatusRoom(Room room)
        {
            bool result = false;
            try
            {
                if (checkExistingRoomInBooking(room.RoomId) == true)
                {
                    if (room.Status == 0)
                    {
                        room.Status = 1;
                        result = true;
                    }
                    else if (room.Status == 1)
                    {
                        room.Status = 0;
                        result = true;
                    }
                    dbContext.SaveChanges();
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
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
                if (checkExistingRoomInBooking(updatedRoomEntity.RoomId) == true)
                {

                    var exsitingRoom = dbContext.Set<Room>().Local.FirstOrDefault(e => e.PartyHostId == updatedRoomEntity.PartyHostId);

                    if (exsitingRoom != null)
                    {
                        dbContext.Entry(exsitingRoom).State = EntityState.Detached;
                    }
                    dbContext.Entry(updatedRoomEntity).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    result = true;
                }
                else
                {
                    result = false;
                }
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

        //List All Room in HomePage for User 
        public async Task<List<Room>> getActiveRoomList()
        {
            List<Room> roomList = null;
            try
            {
                roomList = await dbContext.Rooms.Where(r => r.Status == 1).ToListAsync();
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

                room = dbContext.Rooms.FirstOrDefault(r => r.RoomName.Contains(context));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return room;
        }

        // Get Room By Id
        public Room GetRoomById(int id)
        {
            return dbContext.Rooms.FirstOrDefault(room => room.RoomId == id);
        }


        // Check existing Room By Booking status 
        public bool checkExistingRoomInBooking(int id)
        {
            bool result = false;
            try
            {
                Booking booking = dbContext.Bookings
                                  .Include(b => b.Room)
                                  .Where(b => b.RoomId == id)
                                  .FirstOrDefault(b => b.BookingStatus == 0 || b.BookingStatus == 2);
                if (booking == null)
                {
                    result = true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

    }
}
