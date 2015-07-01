using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDCLLC.Web.Interfaces.Services
{
    public interface ILogService
    {

        #region Error
        
        void Error(Exception exception);

        void Error(string message);

        void Error(string format, params object[] args);

        #endregion


        #region Debug

        void Debug(Exception exception);

        void Debug(string message);

        void Debug(string format, params object[] args); 

        #endregion


        #region Trace

        void Trace(Exception exception);

        void Trace(string message);

        void Trace(string format, params object[] args); 


        #endregion


        #region Info

        void Info(Exception exception);

        void Info(string message);

        void Info(string format, params object[] args); 
        
        #endregion


        #region Warn

        void Warn(Exception exception);

        void Warn(string message);

        void Warn(string format, params object[] args); 
        #endregion


        #region Fatal
        void Fatal(Exception exception);

        void Fatal(string message);

        void Fatal(string format, params object[] args); 
        #endregion
        
    }
}
