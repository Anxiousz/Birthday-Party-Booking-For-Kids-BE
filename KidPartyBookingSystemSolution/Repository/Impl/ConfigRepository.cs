using BusinessObjects;
using BusinessObjects.Request;
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
        public RequestConfigDTO CreateConfig(RequestConfigDTO request)
        {
            return configDAO.CreateConfig(request);
        }

        public Config checkConfigByID(int id)
        {
            return configDAO.checkConfigByID(id);
        }
        public RequestUpdateConfigDTO UpdateConfig(RequestUpdateConfigDTO request)
        {
            return configDAO.UpdateConfig(request);
        }
        public List<Config> GetConfig()
        {
            return configDAO.GetConfig();
        }
    }
}
