using Microsoft.Extensions.Configuration;

namespace FlurTestFramework.Infrastructure;

public static class TestConfiguraiton
{
    public static string ReportPath
    {
        get
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            return configuration["Configurations:ReportPath"];
        }
    }
}