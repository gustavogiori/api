using CrossCutting.Filter;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.DependencyInjection
{
    public static class ConfigureEntities
    {
        public static void ConfigureDependenciesEntitiyes(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IPaginationFilter, PaginationFilter>();
        
        }
    }
}
