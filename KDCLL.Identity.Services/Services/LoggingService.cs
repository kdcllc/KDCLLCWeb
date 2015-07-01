using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;

namespace KDCLLC.Identity.Services
{
    /// <summary>
    /// Utilized Common.Logging
    /// </summary>
    public class LoggingService
    {
        private readonly ILog _log;

        public LoggingService()
        {
            _log = LogManager.GetLogger(GetType());
        }

        public void Warn(object message)
        {
            _log.Warn(message);
        }

        public void Info(object message)
        {
            _log.Info(message);
        }

        public void Exception(Exception ex)
        {
            _log.Error("Error!", ex);
        }
    }
}
