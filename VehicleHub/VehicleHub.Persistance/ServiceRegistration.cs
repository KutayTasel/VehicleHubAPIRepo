using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleHub.Application.IRepositories;
using VehicleHub.Application.IUnitOfWorks;
using VehicleHub.Persistence.Context;
using VehicleHub.Persistence.Repositories;
using VehicleHub.Persistence.UnitOfWorks;

namespace VehicleHub.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<VehicleHubDbContext>(opt => opt.UseSqlServer(Configuration.DefaultConnectionString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), null);

            }));
            services.AddScoped(typeof(IReadRepository<>),typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>),typeof(WriteRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
