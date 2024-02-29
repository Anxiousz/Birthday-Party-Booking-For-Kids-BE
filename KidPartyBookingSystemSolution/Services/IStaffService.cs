using BusinessObjects;
using BusinessObjects.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IStaffService
    {
        public staff GetStaffAccount(RequestAccountLoginDTO request);
        public List<staff> GetStaff();
        public List<staff> SearchStaff(string context);
        public bool checkStaffExistedByEmail(string email);
        public RequestStaffDTO createStaff(RequestStaffDTO request);
        public staff checkStaffExistedByID(int id);
        public bool DeleteStaff(int id);
        public int CountStaff();
    }
}
