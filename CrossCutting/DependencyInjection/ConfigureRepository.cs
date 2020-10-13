using CrossCutting.Validation;
using Data.Context;
using Data.Implementations;
using Data.Repository;
using Domain.Interfaces;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            serviceCollection.AddTransient<IUserRepository, UserImplementation>();
            serviceCollection.AddTransient<IValidationModel, ValidationModel>();
            serviceCollection.AddDbContext<DbContext,MyContext>(
                options => options.UseSqlServer("Data Source=DESKTOP-GNR3UB4;Initial Catalog=API;Integrated Security=True")
            );
        }
    }
}
