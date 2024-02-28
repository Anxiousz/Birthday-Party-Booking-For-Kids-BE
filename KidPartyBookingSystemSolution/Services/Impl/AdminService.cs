using BusinessObjects;
using BusinessObjects.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class AdminService : IAdminService
    {
        private IAdminRepository adminRepository;

        public AdminService()
        {
            adminRepository = new AdminRepository();
        }
        public Admin GetAdminAccount(RequestAccountLoginDTO account)
        {
            try
            {
                if (account == null)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return adminRepository.GetAdminAccount(account);
        }
    }
}
