using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IRegisteredUserService
    {

        public List<RegisteredUser> GetRegisteredUser();
        public RegisteredUser CreateRegisteredUser(RegisteredUser request);      
        public bool DeleteRegisteredUser(int id);
        public bool checkRegisteredUserExistedByEmail(string email); 
        public RegisteredUser checkRegisteredUserExistedByID(int id);
        public RegisteredUser UpdateRegisteredUser(RegisteredUser request);
    }
}
