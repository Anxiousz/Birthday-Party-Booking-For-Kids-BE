using AutoMapper;
using BusinessObjects;
using BusinessObjects.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class StaffDAO
    {
        private static StaffDAO instance = null;
        private readonly PHSContext dbContext = null;
        public StaffDAO()
        {
            if (dbContext == null)
            {
                dbContext = new PHSContext();
            }
        }

        public static StaffDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StaffDAO();
                }
                return instance;
            }
        }

        public staff GetStaffAccount(RequestAccountLoginDTO request)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            IMapper mapper = config.CreateMapper();
            staff staff = mapper.Map<staff>(request);
            return dbContext.staff.FirstOrDefault(a => a.Email.Equals(staff.Email.Trim()) && a.Password.Equals(staff.Password.Trim()));
        }
    }
}
