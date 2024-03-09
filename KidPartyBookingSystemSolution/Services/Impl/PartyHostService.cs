using Azure.Core;
using BusinessObjects;
using BusinessObjects.Request;
using Repository;
using Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class PartyHostService : IPartyHostService
    {
        private IPartyHostRepository partyHostRepository;

        public PartyHostService()
        {
            partyHostRepository = new PartyHostRepository();
        }
        public List<PartyHost> GetPartyHost()
        {
            return partyHostRepository.GetPartyHost();
        }

        public RequestPartyHostDTO CreatePartyHost(RequestPartyHostDTO request)
        {
            return partyHostRepository.CreatePartyHost(request);
        }

        public bool DeletePartyHost(int id)
        {
            return partyHostRepository.DeletePartyHost(id);
        }

        public bool checkPartyHostExistedByEmail(string email)
        {
            return partyHostRepository.checkPartyHostExistedByEmail(email);
        }

        public PartyHost checkPartyHostExistedByID(int id)
        {
            return partyHostRepository.checkPartyHostExistedByID(id);
        }
        public RequestUpdatePartyHostDTO UpdatePartyHost(RequestUpdatePartyHostDTO request)
        {
            return partyHostRepository.UpdatePartyHost(request);
        }
        public int CountPartyHost()
        {
            return partyHostRepository.CountPartyHost();
        }
        public List<PartyHost> searchPartyHost(string context)
        {
            List<PartyHost> list = partyHostRepository.searchPartyHost(context);
            return list;
        }
        public PartyHost GetPartyHostAccount(RequestAccountLoginDTO request)
        {
            try
            {
                if (request == null)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return partyHostRepository.GetPartyHostAccount(request);
        }

        public PartyHost checkPackageExisted(int id)
        {
            try
            {
                if (id == null)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return partyHostRepository.checkPackageExisted(id);
        }
    }
}
