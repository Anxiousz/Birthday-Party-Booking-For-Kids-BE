using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class LogActionDAO
    {
        private static LogActionDAO instance = null;
        private readonly PHSContext dbContext = null;
        public LogActionDAO()
        {
            if (dbContext == null)
            {
                dbContext = new PHSContext();
            }
        }

        public static LogActionDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LogActionDAO();
                }
                return instance;
            }
        }
    }
}
