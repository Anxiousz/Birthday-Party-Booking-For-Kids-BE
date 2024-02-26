using Azure.Core;
using BusinessObjects;
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

        public RegisteredUser CreateRegisteredUser(RegisteredUser request)
        {
            request.Role = 4;
            dbContext.RegisteredUsers.Add(request);
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

        public RegisteredUser UpdateRegisteredUser(RegisteredUser request)
        {
            RegisteredUser checkExisted = checkRegisteredUserExistedByID(request.AccountId);
            if (checkExisted != null)
            {
                dbContext.Entry(checkExisted).CurrentValues.SetValues(request);
                dbContext.Entry(checkExisted).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            return request;
        }
    }
}
