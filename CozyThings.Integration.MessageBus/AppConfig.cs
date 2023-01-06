using Microsoft.Extensions.Configuration;

namespace CozyThings.Integration.MessageBus
{
    internal static class AppConfig
    {
        public static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfiguration configuration = builder.Build();

            return configuration.GetConnectionString("AzureServiceBus");
        }
    }
}
