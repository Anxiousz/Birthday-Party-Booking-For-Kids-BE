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

        public RegisteredUser GetRegisteredUserAccount(string email, string password)
        {
            return registeredUserRepository.GetRegisteredUserAccount(email, password);
        }
    }
}
