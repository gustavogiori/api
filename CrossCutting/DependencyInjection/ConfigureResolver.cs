using Domain;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureResolver
    {
        public static void ConfigureDependencyResolver(IApplicationBuilder app)
        {
            AppDependencyResolver.Init(app.ApplicationServices);
        }
    }
}
