using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleHub.Application.Abstractions;

namespace VehicleHub.Mapper
{
    public static class ServiceRegistration
    {
        public static void AddMapperService(this IServiceCollection services)
        {
            services.AddSingleton<IMyMapper, Mapper>();
        }
    }
}
