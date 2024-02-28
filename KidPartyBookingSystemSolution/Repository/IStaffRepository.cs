using BusinessObjects.Request;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IStaffRepository
    {
        public staff GetStaffAccount(RequestAccountLoginDTO request);
    }
}
