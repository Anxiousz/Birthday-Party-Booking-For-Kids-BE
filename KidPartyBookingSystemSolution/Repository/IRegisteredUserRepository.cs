﻿using BusinessObjects;
using BusinessObjects.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRegisteredUserRepository
    {
        public List<RegisteredUser> GetRegisteredUser();
        public RequestRegisteredUserDTO CreateRegisteredUser(RequestRegisteredUserDTO request);
        public bool DeleteRegisteredUser(int id);
        public bool checkRegisteredUserExistedByEmail(string email);
        public RegisteredUser checkRegisteredUserExistedByID(int id);
        public RequestUpdateRegisteredUserDTO UpdateRegisteredUser(RequestUpdateRegisteredUserDTO request);
        public int CountRegisteredUser();
        public List<RegisteredUser> searchRegisteredUser(string context);
        public RegisteredUser GetRegisteredUserAccount(RequestAccountLoginDTO request);

    }
}
