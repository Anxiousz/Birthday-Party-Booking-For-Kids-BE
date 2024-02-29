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

        public List<staff> GetStaff()
        {
            return dbContext.staff.ToList();
        }

        public List<staff> SearchStaff(string context)
        {
            List<staff> searchAccounts = dbContext.staff
                .Where(x =>
                    x.Email.ToUpper().Contains(context.ToUpper().Trim()) ||
                    x.Address.ToUpper().Contains(context.ToUpper().Trim()) ||
                    x.UserName.ToUpper().Contains(context.ToUpper().Trim()))
                .ToList();
            return searchAccounts;
        }

        public bool checkStaffExistedByEmail(string email)
        {
            bool isExisted = false;
            staff checkAccount = dbContext.staff.FirstOrDefault(x => x.Email == email.Trim());
            if (checkAccount != null)
            {
                isExisted = true;
            }
            return isExisted;
        }

        public RequestStaffDTO createStaff(RequestStaffDTO request)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            IMapper mapper = config.CreateMapper();
            staff staff = mapper.Map<staff>(request);
            staff.Role = "2";
            staff.Status = 1;
            dbContext.staff.Add(staff);
            dbContext.SaveChanges();
            return request;
        }

        public staff checkStaffExistedByID(int id)
        {
            return dbContext.staff.FirstOrDefault(x => x.StaffId == id);
        }
        public bool DeleteStaff(int id)
        {
            staff checkExisted = checkStaffExistedByID(id);
            bool isDeleted = false;
            if (checkExisted != null)
            {
                checkExisted.Status = 0;
                dbContext.SaveChanges();
                isDeleted = true;
            }
            return isDeleted;
        }

        public int CountStaff()
        {
            return dbContext.staff.Count();
        }
    }
}
