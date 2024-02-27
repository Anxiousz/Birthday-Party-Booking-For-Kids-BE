using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class ConfigRepository : IConfigRepository
    {
        private ConfigDAO configDAO;
        public ConfigRepository()
        {
            configDAO = new ConfigDAO();
        }
    }
}
