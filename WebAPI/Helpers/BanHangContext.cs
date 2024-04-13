using BanHang.Entities;
using Microsoft.EntityFrameworkCore;

namespace BanHang.Helpers
{
    public class BanHangContext: DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbSet<Account> Accounts { get; set; }

        public BanHangContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SqlConnectionString"));
        }
    }
}
