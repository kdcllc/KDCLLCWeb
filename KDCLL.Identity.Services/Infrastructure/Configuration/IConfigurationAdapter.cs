
namespace KDCLLC.Identity.Services.Infrastructure.Configuration
{
    public interface IConfigurationAdapter
    {
        T GetSection<T>(string sectionName);
    }
}
