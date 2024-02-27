using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class StaffRepository : IStaffRepository
    {
        private StaffDAO staffDAO;
        public StaffRepository()
        {
            staffDAO = new StaffDAO();
        }
    }
}
