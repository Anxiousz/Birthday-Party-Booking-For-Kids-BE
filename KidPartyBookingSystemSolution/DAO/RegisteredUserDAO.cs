using AutoMapper;
using Azure.Core;
using BusinessObjects;
using BusinessObjects.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class RegisteredUserDAO
    {
        private static RegisteredUserDAO instance = null;
        private readonly PHSContext dbContext = null;
        public RegisteredUserDAO()
        {
            if (dbContext == null)
            {
                dbContext = new PHSContext();
            }
        }

        public static RegisteredUserDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RegisteredUserDAO();
                }
                return instance;
            }
        }

        public List<RegisteredUser> GetRegisteredUser()
        {
            return dbContext.RegisteredUsers.ToList();
        }

        public RequestRegisteredUserDTO CreateRegisteredUser(RequestRegisteredUserDTO request)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            IMapper mapper = config.CreateMapper();
            RegisteredUser registeredUser = mapper.Map<RegisteredUser>(request);
            registeredUser.Role = "4";
            registeredUser.Status = 1;
            dbContext.RegisteredUsers.Add(registeredUser);
            dbContext.SaveChanges();
            return request;
        }

        public bool checkRegisteredUserExistedByEmail(string email)
        {
            bool isExisted = false;
            RegisteredUser checkAccount = dbContext.RegisteredUsers.FirstOrDefault(x => x.Email == email.Trim());
            if (checkAccount != null)
            {
                isExisted = true;
            }
            return isExisted;
        }

        public RegisteredUser checkRegisteredUserExistedByID(int id)
        {
            return dbContext.RegisteredUsers.FirstOrDefault(x => x.AccountId == id);
        }

        public bool DeleteRegisteredUser(int id)
        {
            RegisteredUser checkExisted = checkRegisteredUserExistedByID(id);
            bool isDeleted = false;
            if (checkExisted != null)
            {
                checkExisted.Status = 0;
                dbContext.SaveChanges();
                isDeleted = true;
            }
            return isDeleted;
        }

        public RequestUpdateRegisteredUserDTO UpdateRegisteredUser(RequestUpdateRegisteredUserDTO request)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            IMapper mapper = config.CreateMapper();
            RegisteredUser userToUpdate = mapper.Map<RegisteredUser>(request);
            var existingEntity = dbContext.Set<RegisteredUser>().Local.FirstOrDefault(e => e.AccountId == userToUpdate.AccountId);
            if (existingEntity != null)
            {
                dbContext.Entry(existingEntity).State = EntityState.Detached;
            }
            userToUpdate.Status = 1;
            userToUpdate.Role = "4";
            dbContext.Entry(userToUpdate).State = EntityState.Modified;
            dbContext.SaveChanges();
            return request;
        }
        public int CountRegisteredUser()
        {
            return dbContext.RegisteredUsers.Count();
        }

        public List<RegisteredUser> searchRegisteredUser(string context)
        {
            List<RegisteredUser> searchAccounts = dbContext.RegisteredUsers
                .Where(x =>
                    x.Email.ToUpper().Contains(context.ToUpper().Trim()) ||
                    x.Address.ToUpper().Contains(context.ToUpper().Trim()) ||
                    x.UserName.ToUpper().Contains(context.ToUpper().Trim()))
                .ToList();
            return searchAccounts;
        }

        public RegisteredUser GetRegisteredUserAccount(RequestAccountLoginDTO request)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            IMapper mapper = config.CreateMapper();
            RegisteredUser registeredUser = mapper.Map<RegisteredUser>(request);
            return dbContext.RegisteredUsers.FirstOrDefault(a => a.Email.Equals(registeredUser.Email.Trim()) && a.Password.Equals(registeredUser.Password.Trim()));
        }
    }
}
