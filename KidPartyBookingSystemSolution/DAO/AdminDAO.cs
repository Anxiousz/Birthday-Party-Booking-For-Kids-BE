using AutoMapper;
using Azure.Core;
using BusinessObjects;
using BusinessObjects.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AdminDAO
    {
        private static AdminDAO instance = null;
        private readonly PHSContext dbContext = null;
        public AdminDAO()
        {
            if (dbContext == null)
            {
                dbContext = new PHSContext();
            }
        }

        public static AdminDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AdminDAO();
                }
                return instance;
            }
        }

        public Admin GetAdminAccount(RequestAccountLoginDTO account)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            IMapper mapper = config.CreateMapper();
            Admin admin = mapper.Map<Admin>(account);
            return dbContext.Admins.FirstOrDefault(a => a.Email.Equals(admin.Email.Trim()) && a.Password.Equals(admin.Password.Trim()));
        }
    }
}
