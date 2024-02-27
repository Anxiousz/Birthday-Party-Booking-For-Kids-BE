using Repository.Impl;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class RoomService : IRoomService
    {
        private IRoomRepository roomRepository;

        public RoomService()
        {
            roomRepository = new RoomRepository();
        }
    }
}
