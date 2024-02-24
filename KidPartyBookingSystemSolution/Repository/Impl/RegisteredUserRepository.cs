using BusinessObjects;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Impl
{
    public class RegisteredUserRepository : IRegisteredUserRepository
    {
        private RegisteredUserDAO registeredUserDAO;
        public RegisteredUserRepository()
        {
            registeredUserDAO = new RegisteredUserDAO();
        }

        public RegisteredUser GetRegisteredUserAccount(string email, string password)
        {
            return registeredUserDAO.GetRegisteredUserAccount(email, password);
        }
    }
}
