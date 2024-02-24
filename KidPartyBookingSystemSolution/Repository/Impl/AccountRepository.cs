using BusinessObjects;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Impl
{
    public class AccountRepository : IAccountRepository
    {
        private AccountDAO accountDAO;
        public AccountRepository()
        {
            accountDAO = new AccountDAO();
        }

        public List<RegisteredUser> GetRegisteredUserAccount()
        {
            return accountDAO.GetRegisteredUserAccount();
        }
    }
}
