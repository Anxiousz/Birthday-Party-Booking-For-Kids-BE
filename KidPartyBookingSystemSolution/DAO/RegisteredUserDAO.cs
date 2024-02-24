using BusinessObjects;
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

        public RegisteredUser GetRegisteredUserAccount(string email , string password)
        {
            return dbContext.RegisteredUsers.FirstOrDefault(m => m.Email.Equals(email) &&  m.Password.Equals(password));
        }
    }
}
