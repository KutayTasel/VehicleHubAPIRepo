using FluentValidation;
using IkProject.Application.Expections;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleHub.Application.Beheviors;

namespace VehicleHub.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddExceptionHandler<ExpectionMiddelware>();

            services.AddMediatR(opt => opt.RegisterServicesFromAssemblies(typeof(ServiceRegistration).Assembly));


            services.AddValidatorsFromAssembly(typeof(ServiceRegistration).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));

        }
    }
}
