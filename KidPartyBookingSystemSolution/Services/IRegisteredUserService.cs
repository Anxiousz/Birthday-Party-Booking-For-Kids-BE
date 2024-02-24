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

        public RegisteredUser GetRegisteredUserAccount(string email , string password);
    }
}
