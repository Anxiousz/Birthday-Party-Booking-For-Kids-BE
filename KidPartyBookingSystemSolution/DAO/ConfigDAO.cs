using AutoMapper;
using BusinessObjects;
using BusinessObjects.Request;
using Microsoft.EntityFrameworkCore;
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

        public RequestConfigDTO CreateConfig(RequestConfigDTO request)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            IMapper mapper = config.CreateMapper();
            Config _config = mapper.Map<Config>(request);
            _config.DateTime = DateTime.Now;
            dbContext.Configs.Add(_config);
            dbContext.SaveChanges();
            return request;
        }

        public Config checkConfigByID(int id)
        {
            return dbContext.Configs.FirstOrDefault(x => x.ConfigId == id);
        }
        public RequestUpdateConfigDTO UpdateConfig(RequestUpdateConfigDTO request)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            IMapper mapper = config.CreateMapper();
            Config configToUpdate = mapper.Map<Config>(request);
            var existingEntity = dbContext.Set<Config>().Local.FirstOrDefault(e => e.ConfigId == request.ConfigId);
            if (existingEntity != null)
            {
                dbContext.Entry(existingEntity).State = EntityState.Detached;
            }
            configToUpdate.DateTime = DateTime.Now;
            dbContext.Entry(configToUpdate).State = EntityState.Modified;
            dbContext.SaveChanges();
            return request;
        }
    }
}
