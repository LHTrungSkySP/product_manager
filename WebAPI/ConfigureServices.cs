using Infrastructure;
using Microsoft.OpenApi.Models;

namespace Web.API
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddWebAPI(this IServiceCollection services)
        {
            var assembly = typeof(ConfigureServices);

            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddSwaggerGen(config =>
            {
                config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    In = ParameterLocation.Header,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                config.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });
            return services;
        }
    }
}
