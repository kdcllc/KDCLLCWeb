using System;
using KDCLLC.Web.Interfaces.Services;
using KDCLLC.Web.Services;
using Xunit;

namespace KDCLLC.Web.Tests.Services
{

    public class LogServiceUnitTest
    {
        [Fact]
        public void Log_Info()
        {
            ILogService log = new LogService();

            //if no exception is raised the file is written in Bin\Logs directory
            log.Info("This is test");

        }
    }
}
