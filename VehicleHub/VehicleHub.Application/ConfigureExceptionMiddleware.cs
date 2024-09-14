using IkProject.Application.Expections;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleHub.Application
{
    public static class ConfigureExceptionMiddleware
    {
        public static void ConfigureExceptionHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExpectionMiddelware>();
        }
    }
}
