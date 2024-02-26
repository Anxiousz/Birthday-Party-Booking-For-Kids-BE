using BusinessObjects;
using Repository;
using Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class RegisteredUserService : IRegisteredUserService
    {
        private IRegisteredUserRepository registeredUserRepository;

        public RegisteredUserService()
        {
            registeredUserRepository = new RegisteredUserRepository();
        }

        public List<RegisteredUser> GetRegisteredUser()
        {
            return registeredUserRepository.GetRegisteredUser();
        }

        public RegisteredUser CreateRegisteredUser(RegisteredUser request)
        {
            return registeredUserRepository.CreateRegisteredUser(request);
        }

        public bool DeleteRegisteredUser(int id)
        {
            return registeredUserRepository.DeleteRegisteredUser(id);
        }

        public bool checkRegisteredUserExistedByEmail(string email)
        {
            return registeredUserRepository.checkRegisteredUserExistedByEmail(email);
        }

        public RegisteredUser checkRegisteredUserExistedByID(int id)
        {
            return registeredUserRepository.checkRegisteredUserExistedByID(id);
        }
        public RegisteredUser UpdateRegisteredUser(RegisteredUser request)
        {
            return registeredUserRepository.UpdateRegisteredUser(request);
        }
    }
}
