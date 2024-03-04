using Repository.Impl;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using BussinessObjects.Request;

namespace Services.Impl
{
    public class VoucherService : IVoucherService
    {
        private IVoucherRepository voucherRepository;

        public VoucherService()
        {
            voucherRepository = new VoucherRepository();
        }
        public Voucher checkVoucherExistedByID(int id)
        {
            return voucherRepository.checkVoucherExistedByID(id);
        }

        public bool checkVoucherExistedByReissued(int reissued)
        {
            return voucherRepository.checkVoucherExistedByReissued(reissued);
        }

        public int CountVoucher()
        {
            return voucherRepository.CountVoucher();
        }

        public RequestVoucherDTO CreateVoucher(RequestVoucherDTO request)
        {
            return voucherRepository.CreateVoucher(request);
        }

        public bool DeleteVoucher(int id)
        {
            return voucherRepository.DeleteVoucher(id);
        }

        public List<Voucher> GetVoucher()
        {
            return voucherRepository.GetVoucher();
        }

        public Voucher GetVoucherById(int id)
        {
            return voucherRepository.GetVoucherById(id);
        }

        public List<Voucher> searchVoucher(string context)
        {
            return voucherRepository.searchVoucher(context);
        }

        public Voucher UpdateVoucher(Voucher request)
        {
            return voucherRepository.UpdateVoucher(request);
        }
    }
}
