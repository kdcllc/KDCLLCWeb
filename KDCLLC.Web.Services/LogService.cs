using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDCLLC.Web.Interfaces.Services;
using Common.Logging;

namespace KDCLLC.Web.Services
{
    public class LogService : ILogService
    {   
        private readonly ILog _logger  = LogManager.GetLogger(typeof(LogService));

        #region Error
        public void Error(Exception exception)
        {
            _logger.Error("Exception", exception);
        }

        public void Error(string format, params object[] args)
        {
            _logger.Error(String.Format(format, args));
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        #endregion

        #region Debug
        public void Debug(string format, params object[] args)
        {
            _logger.Debug(String.Format(format, args));
        }

        public void Debug(Exception exception)
        {
            _logger.Debug(exception);
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        } 
        #endregion


        #region Trace
        public void Trace(string format, params object[] args)
        {
            _logger.Trace(String.Format(format, args));
        }


        public void Trace(Exception exception)
        {
            _logger.Trace(exception);
        }

        public void Trace(string message)
        {
            _logger.Trace(message);
        } 
        #endregion

        #region Info
        public void Info(string format, params object[] args)
        {
            _logger.Info(String.Format(format, args));
        }

        public void Info(Exception exception)
        {
            _logger.Info(exception);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        } 
        #endregion


        #region Warn
        public void Warn(string format, params object[] args)
        {
            _logger.Warn(String.Format(format, args));
        }

        public void Warn(Exception exception)
        {
            _logger.Warn(exception);
        }

        public void Warn(string message)
        {
            _logger.Warn(message);
        } 
        #endregion

        #region Fatal
        public void Fatal(string format, params object[] args)
        {
            _logger.Fatal(String.Format(format, args));
        }


        public void Fatal(Exception exception)
        {
            _logger.Fatal(exception);
        }

        public void Fatal(string message)
        {
            _logger.Fatal(message);
        } 
        #endregion
    }
}
