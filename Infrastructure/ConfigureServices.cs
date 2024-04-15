using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "Infrastructure"))
                .AddJsonFile("appsettings.json")
                .Build(); ;

            // configure strongly typed settings object
            var appSettings = new AppSettings();
            configuration.GetSection("AppSettings").Bind(appSettings);

            // Return an Action<AppSettings> that configures AppSettings using the bound values
            Action<AppSettings> configureAppSettings = settings =>
            {
                settings.Secret = appSettings.Secret;
                // Assign other settings as needed
            };
            // configure strongly typed settings object
            services.Configure(configureAppSettings);

            // services.AddQueryRepository<AppDbContext>();
            services.AddDbContext<BanHangContext>();
            return services;
        }
    }
}
