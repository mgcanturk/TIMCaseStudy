using Microsoft.Extensions.Configuration;

namespace TIMCaseStudy.Persistence
{
    static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/TIMCaseStudy.API"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("MsSQL");
            }
        }
    }
}
