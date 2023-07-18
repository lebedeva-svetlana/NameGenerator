using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EgrnNet6
{
    public static class SettingsHelper
    {
        public static string GetString(string key)
        {
            using IHost host = Host.CreateDefaultBuilder().Build();
            IConfiguration config = host.Services.GetRequiredService<IConfiguration>();
            return config[key];
        }
    }
}