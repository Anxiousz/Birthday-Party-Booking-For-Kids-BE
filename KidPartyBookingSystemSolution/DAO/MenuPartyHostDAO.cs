using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class MenuPartyHostDAO
    {
        private static MenuPartyHostDAO instance = null;
        private readonly PHSContext dbContext = null;
        public MenuPartyHostDAO()
        {
            if (dbContext == null)
            {
                dbContext = new PHSContext();
            }
        }

        public static MenuPartyHostDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MenuPartyHostDAO();
                }
                return instance;
            }
        }
    }
}
