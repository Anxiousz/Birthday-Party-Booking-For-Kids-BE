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
    public class AccountService : IAccountService
    {
        private IAccountRepository _accountRepo;

        public AccountService()
        {
            _accountRepo = new AccountRepository();
        }

        public List<RegisteredUser> GetRegisteredUserAccount()
        {
            return _accountRepo.GetRegisteredUserAccount();
        }
    }
}
