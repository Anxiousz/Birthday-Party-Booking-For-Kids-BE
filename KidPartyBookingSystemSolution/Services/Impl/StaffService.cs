using Repository.Impl;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using BusinessObjects.Request;

namespace Services.Impl
{
    public class StaffService : IStaffService
    {
        private IStaffRepository staffRepository;

        public StaffService()
        {
            staffRepository = new StaffRepository();
        }

        public staff GetStaffAccount(RequestAccountLoginDTO request)
        {
            try
            {
                if(request == null)
                {
                    throw new Exception();
                }
            }catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return staffRepository.GetStaffAccount(request);
        }
    }
}
