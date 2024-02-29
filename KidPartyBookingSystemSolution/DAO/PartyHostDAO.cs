using AutoMapper;
using BusinessObjects;
using BusinessObjects.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PartyHostDAO
    {
        private static PartyHostDAO instance = null;
        private readonly PHSContext dbContext = null;
        public PartyHostDAO()
        {
            if (dbContext == null)
            {
                dbContext = new PHSContext();
            }
        }

        public static PartyHostDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PartyHostDAO();
                }
                return instance;
            }
        }
        public List<PartyHost> GetPartyHost()
        {
            List<PartyHost> partyHosts = dbContext.PartyHosts.ToList();
            return partyHosts;
        }

        public RequestPartyHostDTO CreatePartyHost(RequestPartyHostDTO request)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            IMapper mapper = config.CreateMapper();
            PartyHost partyHost = mapper.Map<PartyHost>(request);
            partyHost.Role = "3";
            partyHost.Status = 1;
            dbContext.PartyHosts.Add(partyHost);
            dbContext.SaveChanges();
            return request;
        }


        public bool checkPartyHostExistedByEmail(string email)
        {
            bool isExisted = false;
            PartyHost checkAccount = dbContext.PartyHosts.FirstOrDefault(x => x.Email == email.Trim());
            if (checkAccount != null)
            {
                isExisted = true;
            }
            return isExisted;
        }

        public PartyHost checkPartyHostExistedByID(int id)
        {
            return dbContext.PartyHosts.FirstOrDefault(x => x.PartyHostId == id);
        }

        public bool DeletePartyHost(int id)
        {
            PartyHost checkExisted = checkPartyHostExistedByID(id);
            bool isDeleted = false;
            if (checkExisted != null)
            {
                checkExisted.Status = 0;
                dbContext.SaveChanges();
                isDeleted = true;
            }
            return isDeleted;
        }

        public PartyHost UpdatePartyHost(PartyHost request)
        {
            PartyHost checkExisted = checkPartyHostExistedByID(request.PartyHostId);
            if (checkExisted != null)
            {
                dbContext.Entry(checkExisted).CurrentValues.SetValues(request);
                dbContext.Entry(checkExisted).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            return request;
        }

        public int CountPartyHost()
        {
            return dbContext.PartyHosts.Count();
        }

        public List<PartyHost> searchPartyHost(string context)
        {
            List<PartyHost> searchAccounts = dbContext.PartyHosts
                .Where(x =>
                    x.Email.ToUpper().Contains(context.ToUpper().Trim()) ||
                    x.Address.ToUpper().Contains(context.ToUpper().Trim()) ||
                    x.UserName.ToUpper().Contains(context.ToUpper().Trim()))
                .ToList();
            return searchAccounts;
        }

        public PartyHost GetPartyHostAccount(RequestAccountLoginDTO request)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            IMapper mapper = config.CreateMapper();
            PartyHost partyHost = mapper.Map<PartyHost>(request);
            return dbContext.PartyHosts.FirstOrDefault(a => a.Email.Equals(partyHost.Email.Trim()) && a.Password.Equals(partyHost.Password.Trim()));
        }

        public PartyHost checkPackageExisted(int id)
        {
            return dbContext.PartyHosts.FirstOrDefault(a => a.PackageId == id);
        }
    }
}