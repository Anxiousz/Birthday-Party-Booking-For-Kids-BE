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
        public List<staff> GetStaff()
        {
            return staffDAO.GetStaff();
        }
        public List<staff> SearchStaff(string context)
        {
            return staffDAO.SearchStaff(context);
        }
        public bool checkStaffExistedByEmail(string email)
        {
            return staffDAO.checkStaffExistedByEmail(email);
        }
        public RequestStaffDTO createStaff(RequestStaffDTO request)
        {
            return staffDAO.createStaff(request);
        }
        public staff checkStaffExistedByID(int id)
        {
            return staffDAO.checkStaffExistedByID(id);
        }
        public bool DeleteStaff(int id)
        {
            return staffDAO.DeleteStaff(id);
        }
        public int CountStaff()
        {
            return staffDAO.CountStaff();
        }

    }
}
