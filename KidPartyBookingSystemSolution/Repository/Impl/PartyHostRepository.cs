using BusinessObjects;
using BusinessObjects.Request;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Impl
{
    public class PartyHostRepository : IPartyHostRepository
    {
        private PartyHostDAO partyHostDAO;
        public PartyHostRepository()
        {
            partyHostDAO = new PartyHostDAO();
        }
        public List<PartyHost> GetPartyHost()
        {
            return partyHostDAO.GetPartyHost();
        }

        public RequestPartyHostDTO CreatePartyHost(RequestPartyHostDTO request)
        {
            return partyHostDAO.CreatePartyHost(request);
        }

        public bool DeletePartyHost(int id)
        {
            return partyHostDAO.DeletePartyHost(id);
        }

        public bool checkPartyHostExistedByEmail(string email)
        {
            return partyHostDAO.checkPartyHostExistedByEmail(email);
        }

        public PartyHost checkPartyHostExistedByID(int id)
        {
            return partyHostDAO.checkPartyHostExistedByID(id);
        }
        public RequestUpdatePartyHostDTO UpdatePartyHost(RequestUpdatePartyHostDTO request)
        {
            return partyHostDAO.UpdatePartyHost(request);
        }
        public int CountPartyHost()
        {
            return partyHostDAO.CountPartyHost();
        }
        public List<PartyHost> searchPartyHost(string context)
        {
            return partyHostDAO.searchPartyHost(context);
        }

        public PartyHost GetPartyHostAccount(RequestAccountLoginDTO request)
        {
            return partyHostDAO.GetPartyHostAccount(request);
        }
        public PartyHost checkPackageExisted(int id)
        {
            return partyHostDAO.checkPackageExisted(id);
        }
    }
}
