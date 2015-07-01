using System.Configuration;

namespace KDCLLC.Identity.Services.Infrastructure.Configuration
{
    public class ConfigurationAdapter : IConfigurationAdapter
    {
        public T GetSection<T>(string sectionName)
        {
            return (T)ConfigurationManager.GetSection(sectionName);
        }
    }
}
