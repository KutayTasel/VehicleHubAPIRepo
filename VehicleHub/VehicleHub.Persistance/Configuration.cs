using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleHub.Persistence
{
    public static class Configuration
    {
        private static IConfigurationRoot configuration;
        static Configuration() {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
        public static string DefaultConnectionString => configuration.GetConnectionString("VehicleHubDbContextttt");
    }
}
