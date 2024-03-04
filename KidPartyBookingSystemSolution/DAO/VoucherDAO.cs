using AutoMapper;
using BusinessObjects;
using BussinessObjects.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class VoucherDAO
    {
        private static VoucherDAO instance = null;
        private readonly PHSContext dbContext = null;
        public VoucherDAO()
        {
            if (dbContext == null)
            {
                dbContext = new PHSContext();
            }
        }

        public static VoucherDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VoucherDAO();
                }
                return instance;
            }
        }

        public bool checkVoucherExistedByReissued(int by)
        {
            bool isExisted = false;
            Voucher checkAccount = dbContext.Vouchers.FirstOrDefault(x => x.ReissuedBy == by);
            if (checkAccount != null)
            {
                isExisted = true;
            }
            return isExisted;
        }

        public Voucher checkVoucherExistedByID(int id)
        {
            return dbContext.Vouchers.FirstOrDefault(x => x.VoucherId == id);
        }
        public List<Voucher> GetVouchers()
        {
            List<Voucher> voucher = dbContext.Vouchers.ToList();
            return voucher;
        }

        public Voucher GetVoucherById(int id)
        {
            return dbContext.Vouchers.FirstOrDefault(v => v.VoucherId == id);
        }
        public RequestVoucherDTO CreateVoucher(RequestVoucherDTO request)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            IMapper mapper = config.CreateMapper();
            Voucher voucher = mapper.Map<Voucher>(request);
            dbContext.Vouchers.Add(voucher);
            dbContext.SaveChanges();
            return request;
        }
        public bool DeleteVoucher(int id)
        {
            Voucher checkExisted = checkVoucherExistedByID(id);
            bool isDeleted = false;
            if (checkExisted != null)
            {
                dbContext.Vouchers.Remove(checkExisted);
                dbContext.SaveChanges();
                isDeleted = true;
            }
            return isDeleted;
        }

        public Voucher UpdateVoucher(Voucher request)
        {
            Voucher checkExisted = checkVoucherExistedByID(request.VoucherId);
            if (checkExisted != null)
            {
                dbContext.Entry(checkExisted).CurrentValues.SetValues(request);
                dbContext.Entry(checkExisted).State = EntityState.Modified;
                dbContext.SaveChanges();
                return request;
            }
            return request;
        }

        public int CountVoucher()
        {
            return dbContext.Vouchers.Count();
        }

        public List<Voucher> searchVoucher(string context)
        {
            List<Voucher> searchVoucher = dbContext.Vouchers
                .Where(x =>
                    x.FromDate.ToString().ToUpper().Contains(context.ToUpper().Trim()) ||
                    x.ToDate.ToString().ToUpper().Contains(context.ToUpper().Trim()))
                .ToList();
            return searchVoucher;
        }
    }
}
