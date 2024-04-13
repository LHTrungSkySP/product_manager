
using BanHang.Authorization;
using BanHang.Helpers;
using BanHang.Services;
using Microsoft.OpenApi.Models;

namespace BanHang
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<BanHangContext>();
            // configure strongly typed settings object
            //builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

            // auto map
            builder.Services.AddAutoMapper(typeof(Program));

            // configure strongly typed settings object
            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IJwtUtils, JwtUtils>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(config =>
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