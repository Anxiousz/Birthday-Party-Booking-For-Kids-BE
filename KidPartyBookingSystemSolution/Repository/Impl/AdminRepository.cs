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
    public class AdminRepository : IAdminRepository
    {
        private AdminDAO adminDAO;
        public AdminRepository()
        {
            adminDAO = new AdminDAO();
        }
        public Admin GetAdminAccount(RequestAccountLoginDTO account)
        {
            return adminDAO.GetAdminAccount(account);
        }
    }
}
