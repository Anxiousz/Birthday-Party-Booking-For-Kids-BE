using BusinessObjects;
using BusinessObjects.Request;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class PackageRepository : IPackageRepository
    {

        private PackageDAO packageDAO;
        public PackageRepository()
        {
            packageDAO = new PackageDAO();
        }
        public int CountPackage()
        {
            return packageDAO.CountPackage();
        }
        public List<Package> GetAllPackages()
        {
            return packageDAO.GetAllPackages();
        }
        public Package GetPackageById(int id)
        {
            return packageDAO.GetPackageById(id);
        }
        public RequestPackageCreateDTO CreatePackage(RequestPackageCreateDTO request)
        {
            return packageDAO.CreatePackage(request);
        }
        public bool deletePackage(int id)
        {
            return packageDAO.deletePackage(id);
        }
        public Package GetPackageByID(int id)
        {
            return packageDAO.GetPackageByID(id);
        }
        public RequestPackageUpdateDTO UpdatePackage(RequestPackageUpdateDTO request)
        {
            return packageDAO.UpdatePackage(request);
        }
    }
}
