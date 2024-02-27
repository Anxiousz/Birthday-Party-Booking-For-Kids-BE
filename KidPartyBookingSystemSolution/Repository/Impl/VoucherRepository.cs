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
    }
}
