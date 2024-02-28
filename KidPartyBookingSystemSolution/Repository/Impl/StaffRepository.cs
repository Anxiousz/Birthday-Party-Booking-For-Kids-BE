using BusinessObjects;
using BusinessObjects.Request;
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

        public staff GetStaffAccount(RequestAccountLoginDTO request)
        {
            return staffDAO.GetStaffAccount(request);
        }
    }
}
