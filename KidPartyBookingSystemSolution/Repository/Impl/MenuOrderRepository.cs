using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class MenuOrderRepository : IMenuOrderRepository
    {
        private MenuOrderDAO menuOrderDAO;
        public MenuOrderRepository()
        {
            menuOrderDAO = new MenuOrderDAO();
        }
    }
}
