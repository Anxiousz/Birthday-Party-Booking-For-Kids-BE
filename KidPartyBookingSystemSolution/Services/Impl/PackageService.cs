using Repository.Impl;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using BusinessObjects.Request;

namespace Services.Impl
{
    public class PackageService : IPackageService
    {
        private IPackageRepository packageRepository;

        public PackageService()
        {
            packageRepository = new PackageRepository();
        }

        public int CountPackage()
        {
            return packageRepository.CountPackage();
        }
        public List<Package> GetAllPackages()
        {
            return packageRepository.GetAllPackages();
        }
        public Package GetPackageById(int id)
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
            return packageRepository.GetPackageById(id);
        }

        public RequestPackageCreateDTO CreatePackage(RequestPackageCreateDTO request)
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
            return packageRepository.CreatePackage(request);
        }
        public bool deletePackage(int id)
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
            return packageRepository.deletePackage(id);
        }
        public Package GetPackageByID(int id)
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
            return packageRepository.GetPackageByID(id);
        }
        public RequestPackageUpdateDTO UpdatePackage(RequestPackageUpdateDTO request)
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
            return packageRepository.UpdatePackage(request);
        }
    }
}
