using AutoMapper;
using Azure.Core;
using BusinessObjects;
using BusinessObjects.Request;
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
        public RequestRoomDTO CreateNewRoom( RequestRoomDTO roomRequest)
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

        // Update Room
        public bool UpdateRoom(int id, RequestRoomDTO updatedRoom)
        {
            try
            {
                // Lấy thông tin phòng hiện tại từ cơ sở dữ liệu
                Room room = getRoomById(id);

                if (room != null)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.AddProfile<MappingProfile>();
                    });
                    IMapper mapper = config.CreateMapper();
                    Room updatedRoomEntity = mapper.Map<Room>(updatedRoom);

                    // Kiểm tra giá trị PartyHostId trong bảng PartyHosts
                    if (dbContext.PartyHosts.Any(p => p.PartyHostId == updatedRoomEntity.PartyHostId))
                    {
                        // Cập nhật thông tin của phòng
                        room.RoomName = updatedRoomEntity.RoomName;
                        room.RoomType = updatedRoomEntity.RoomType;
                        room.Capacity = updatedRoomEntity.Capacity;
                        room.TimeStart = updatedRoomEntity.TimeStart;
                        room.TimeEnd = updatedRoomEntity.TimeEnd;
                        room.Location = updatedRoomEntity.Location;
                        room.Price = updatedRoomEntity.Price;
                        room.Note = updatedRoomEntity.Note;
                        room.Status = 1;  // Cập nhật trạng thái, bạn có thể điều chỉnh tùy theo yêu cầu của bạn

                        // Lưu các thay đổi vào cơ sở dữ liệu
                        dbContext.SaveChanges();

                        return true;  // Trả về true để biểu thị rằng cập nhật thành công
                    }
                    else
                    {
                        throw new Exception("Giá trị 'PartyHostId' không hợp lệ.");
                    }
                }
                else
                {
                    throw new Exception("Không tìm thấy phòng với ID đã cho.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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

        // 
    }
}
