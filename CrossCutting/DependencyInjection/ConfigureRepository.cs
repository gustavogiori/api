using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            //serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            //serviceCollection.AddScoped<IUserRepository, UserImplementation>();

            //serviceCollection.AddScoped<IUfRepository, UfImplementation>();
            //serviceCollection.AddScoped<IMunicipioRepository, MunicipioImplementation>();
            //serviceCollection.AddScoped<ICepRepository, CepImplementation>();

            if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "SQLSERVER".ToLower())
            {
                serviceCollection.AddDbContext<DbContext>(
                    options => options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION"))
                );
            }
        }
    }
}
