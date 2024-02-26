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

        public List<RegisteredUser> GetRegisteredUser()
        {
            return registeredUserDAO.GetRegisteredUser();
        }

        public RegisteredUser CreateRegisteredUser(RegisteredUser request)
        {
            return registeredUserDAO.CreateRegisteredUser(request);
        }

        public bool DeleteRegisteredUser(int id)
        {
            return registeredUserDAO.DeleteRegisteredUser(id);
        }

        public bool checkRegisteredUserExistedByEmail(string email)
        {
            return registeredUserDAO.checkRegisteredUserExistedByEmail(email);
        } 

        public RegisteredUser checkRegisteredUserExistedByID(int id)
        {
            return registeredUserDAO.checkRegisteredUserExistedByID(id);
        }
        public RegisteredUser UpdateRegisteredUser(RegisteredUser request)
        {
            return registeredUserDAO.UpdateRegisteredUser(request);
        }
    }
}
