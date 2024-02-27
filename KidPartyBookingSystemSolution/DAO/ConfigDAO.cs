using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ConfigDAO
    {
        private static ConfigDAO instance = null;
        private readonly PHSContext dbContext = null;
        public ConfigDAO()
        {
            if (dbContext == null)
            {
                dbContext = new PHSContext();
            }
        }

        public static ConfigDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConfigDAO();
                }
                return instance;
            }
        }
    }
}
