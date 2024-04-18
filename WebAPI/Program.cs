using Infrastructure;
using Microsoft.OpenApi.Models;
using Application;
using Web.API.Middlewares;
using Web.API;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.ClearProviders();
            builder.Logging.AddLog4Net();
            builder.Logging.AddConsole().AddSimpleConsole(
                options =>
                {
                    options.IncludeScopes = true;
                    options.SingleLine = true;
                    options.TimestampFormat = "yyyy-MM-dd HH:mm:ss ";
                }
            );
            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
            builder.Services
                .AddInfrastructure()
                .AddApplication()
                .AddWebAPI();

            var app = builder.Build();           

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            // middle set up
            // global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseMiddleware<JwtMiddleware>();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}