using Microsoft.Extensions.DependencyInjection;
using Utility.Authorizations;

namespace Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //    .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "Infrastructure"))
            //    .AddJsonFile("appsettings.json")
            //    .Build(); ;
            var assembly = typeof(ConfigureServices).Assembly;
            services.AddScoped<IJwtUtils, JwtUtils>();

            services.AddAutoMapper(assembly);

            return services;
        }
    }
}
