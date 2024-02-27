using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class MenuPartyHostRepository : IMenuPartyHostRepository
    {
        private MenuPartyHostDAO menuPartyHostDAO;
        public MenuPartyHostRepository()
        {
            menuPartyHostDAO = new MenuPartyHostDAO();
        }
    }
}
