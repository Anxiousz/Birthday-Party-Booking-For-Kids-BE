using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class MenuOrderDAO
    {
        private static MenuOrderDAO instance = null;
        private readonly PHSContext dbContext = null;
        public MenuOrderDAO()
        {
            if (dbContext == null)
            {
                dbContext = new PHSContext();
            }
        }

        public static MenuOrderDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MenuOrderDAO();
                }
                return instance;
            }
        }
    }
}
