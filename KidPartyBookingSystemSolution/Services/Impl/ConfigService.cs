using Repository.Impl;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Request;
using BusinessObjects;

namespace Services.Impl
{
    public class ConfigService : IConfigService
    {
        private IConfigRepository configRepository;

        public ConfigService()
        {
            configRepository = new ConfigRepository();
        }
        public RequestConfigDTO CreateConfig(RequestConfigDTO request)
        {
            try
            {
                if(request == null)
                {
                    throw new Exception();
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return configRepository.CreateConfig(request);
        }

        public Config checkConfigByID(int id)
        {
            try
            {
                if (id == null)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return configRepository.checkConfigByID(id);
        }

        public RequestUpdateConfigDTO UpdateConfig(RequestUpdateConfigDTO request)
        {
            try
            {
                if (request == null)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return configRepository.UpdateConfig(request);
        }
        public List<Config> GetConfig()
        {
            return configRepository.GetConfig();
        }
    }
}
