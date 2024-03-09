using BusinessObjects;
using BusinessObjects.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IPartyHostService
    {
        public List<PartyHost> GetPartyHost();
        public RequestPartyHostDTO CreatePartyHost(RequestPartyHostDTO request);
        public bool DeletePartyHost(int id);
        public bool checkPartyHostExistedByEmail(string email);
        public PartyHost checkPartyHostExistedByID(int id);
        public RequestUpdatePartyHostDTO UpdatePartyHost(RequestUpdatePartyHostDTO request);
        public int CountPartyHost();
        public List<PartyHost> searchPartyHost(string context);
        public PartyHost GetPartyHostAccount(RequestAccountLoginDTO request);
        public PartyHost checkPackageExisted(int id);
    }
}
