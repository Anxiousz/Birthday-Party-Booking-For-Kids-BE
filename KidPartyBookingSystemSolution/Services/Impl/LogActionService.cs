using Repository.Impl;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class LogActionService : ILogActionService
    {
        private ILogActionRepository logActionRepository;

        public LogActionService()
        {
            logActionRepository = new LogActionRepository();
        }
    }
}
