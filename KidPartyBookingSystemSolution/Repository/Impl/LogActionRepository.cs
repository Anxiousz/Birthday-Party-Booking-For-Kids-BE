using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class LogActionRepository : ILogActionRepository
    {
        private LogActionDAO logActionDAO;
        public LogActionRepository()
        {
            logActionDAO = new LogActionDAO();
        }
    }
}
