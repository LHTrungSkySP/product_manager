﻿using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text.Json.Serialization;
using Utility.Authorizations;
using Utility.FileLog;
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
            //services.AddScoped<IUserService, UserService>();

            services.AddAutoMapper(assembly);
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(assembly);
            });
            return services;
        }
    }
}
