using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public class BanHangContext: DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        //protected readonly IConfiguration Configuration;

        //public BanHangContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "Infrastructure"))
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlConnectionString"));
        }
    }
    //public class WebContextFactory : IDesignTimeDbContextFactory<BanHangContext>
    //{
    //    public BanHangContext CreateDbContext(string[] args)
    //    {
    //        IConfigurationRoot configuration = new ConfigurationBuilder()
    //        .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "Infrastructure"))
    //        .AddJsonFile("appsettings.json")
    //        .Build(); ;
    //        return new BanHangContext(configuration);
    //    }
    //}
}
