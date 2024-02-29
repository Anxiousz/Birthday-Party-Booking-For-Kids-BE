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
    public class PackageDAO
    {
        private static PackageDAO instance = null;
        private readonly PHSContext dbContext = null;
        public PackageDAO()
        {
            if (dbContext == null)
            {
                dbContext = new PHSContext();
            }
        }

        public static PackageDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PackageDAO();
                }
                return instance;
            }
        }
        public int CountPackage()
        {
            return dbContext.Packages.Count();
        }
        public List<Package> GetAllPackages()
        {
            return dbContext.Packages.ToList();
        }
        public Package GetPackageById(int id)
        {
            return dbContext.Packages.FirstOrDefault(x => x.PackageId == id);
        }
        public RequestPackageCreateDTO CreatePackage(RequestPackageCreateDTO request)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            IMapper mapper = config.CreateMapper();
            Package package = mapper.Map<Package>(request);
            dbContext.Packages.Add(package);
            dbContext.SaveChanges();
            return request;
        }

        public Package GetPackageByID(int id)
        {
            return dbContext.Packages.FirstOrDefault(x => x.PackageId == id);
        }

        public bool deletePackage(int id)
        {
            Package checkExisted = GetPackageByID(id);
            bool isDeleted = false;
            if (checkExisted != null)
            {
                dbContext.Packages.Remove(checkExisted);
                dbContext.SaveChanges();
                isDeleted = true;
            }
            return isDeleted;
        }

        public RequestPackageUpdateDTO UpdatePackage(RequestPackageUpdateDTO request)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            IMapper mapper = config.CreateMapper();
            Package packageToUpdate = mapper.Map<Package>(request);
            var existingEntity = dbContext.Set<Package>().Local.FirstOrDefault(e => e.PackageId == packageToUpdate.PackageId);
            if (existingEntity != null)
            {
                dbContext.Entry(existingEntity).State = EntityState.Detached;
            }

            dbContext.Entry(packageToUpdate).State = EntityState.Modified;
            dbContext.SaveChanges();
            return request;
        }
    }
}