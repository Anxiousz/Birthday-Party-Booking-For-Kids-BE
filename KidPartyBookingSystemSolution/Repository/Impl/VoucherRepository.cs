using BusinessObjects;
using BussinessObjects.Request;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class VoucherRepository : IVoucherRepository
    {
        private VoucherDAO voucherDAO;
        public VoucherRepository()
        {
            voucherDAO = new VoucherDAO();
        }
        public Voucher checkVoucherExistedByID(int id)
        {
            return voucherDAO.checkVoucherExistedByID(id);
        }

        public bool checkVoucherExistedByReissued(int reissued)
        {
            return voucherDAO.checkVoucherExistedByReissued(reissued);
        }

        public int CountVoucher()
        {
            return voucherDAO.CountVoucher();
        }

        public RequestVoucherDTO CreateVoucher(RequestVoucherDTO request)
        {
            return voucherDAO.CreateVoucher(request);
        }

        public bool DeleteVoucher(int id)
        {
            return voucherDAO.DeleteVoucher(id);
        }

        public List<Voucher> GetVoucher()
        {
            return voucherDAO.GetVouchers();
        }

        public Voucher GetVoucherById(int id)
        {
            return voucherDAO.GetVoucherById(id);
        }

        public List<Voucher> searchVoucher(string context)
        {
            return voucherDAO.searchVoucher(context);
        }

        public Voucher UpdateVoucher(Voucher request)
        {
            return voucherDAO.UpdateVoucher(request);
        }
    }
}
