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
    }
}
