using Microsoft.Extensions.Configuration;

namespace CozyThings.Integration.MessageBus
{
    internal static class AppConfig
    {
        public static string GetConnectionString()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), optional: false)
                .Build();

            return configuration.GetSection("AppSettings").GetSection("ConnectionString").Value!;
        }
    }
}
