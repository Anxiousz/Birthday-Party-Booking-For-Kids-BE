using Repository.Impl;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using BusinessObjects.Request;
using Azure.Core;
using Microsoft.EntityFrameworkCore;

namespace Services.Impl
{
    public class StaffService : IStaffService
    {
        private IStaffRepository staffRepository;

        public StaffService()
        {
            staffRepository = new StaffRepository();
        }

        public staff GetStaffAccount(RequestAccountLoginDTO request)
        {
            try
            {
                if(request == null)
                {
                    throw new Exception();
                }
            }catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return staffRepository.GetStaffAccount(request);
        }

        public List<staff> GetStaff()
        {
            return staffRepository.GetStaff();
        }

        public List<staff> SearchStaff(string context)
        {
            try
            {
                if (context == null)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return staffRepository.SearchStaff(context);
        }

        public bool checkStaffExistedByEmail(string email)
        {
            try
            {
                if (email == null)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return staffRepository.checkStaffExistedByEmail(email);
        }

        public RequestStaffDTO createStaff(RequestStaffDTO request)
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
            return staffRepository.createStaff(request);
        }

        public staff checkStaffExistedByID(int id)
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
            return staffRepository.checkStaffExistedByID(id);
        }
        public bool DeleteStaff(int id)
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
            return staffRepository.DeleteStaff(id);
        }
        public int CountStaff()
        {
            return staffRepository.CountStaff();
        }
    }
}
