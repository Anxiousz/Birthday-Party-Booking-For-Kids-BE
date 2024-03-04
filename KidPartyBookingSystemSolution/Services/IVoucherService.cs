using BusinessObjects;
using BussinessObjects.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IVoucherService
    {
        public List<Voucher> GetVoucher();
        public Voucher GetVoucherById(int id);
        public RequestVoucherDTO CreateVoucher(RequestVoucherDTO request);
        public bool DeleteVoucher(int id);
        public Voucher UpdateVoucher(Voucher request);
        public List<Voucher> searchVoucher(string context);
        public int CountVoucher();
        public bool checkVoucherExistedByReissued(int reissued);
        public Voucher checkVoucherExistedByID(int id);
    }
}
