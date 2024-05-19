using Domain.Entities;
using Humanizer.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public class BanHangContext: DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AssignGroup> AssignGroups { get; set; }
        public DbSet<GroupPermission> GroupPermissions { get; set; }
        public DbSet<AssignPermission> AssignPermissions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        protected readonly IConfiguration Configuration;
        public BanHangContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //    .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
            //    .AddJsonFile("appsettings.json")
            //    .Build();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SqlConnectionString"));
        }
        public override int SaveChanges()

        {
            OnBeforeSaving();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeSaving()
        {
            IEnumerable<EntityEntry> entries = ChangeTracker.Entries();
            DateTime utcNow = DateTime.UtcNow;

            foreach (EntityEntry entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        // Set UpdatedDate to current date/time for updated entities
                        entry.Property("UpdatedDate").CurrentValue = utcNow;
                        break;
                    case EntityState.Added:
                        // Set CreatedDate and UpdatedDate to current date/time for new entities
                        entry.Property("CreatedDate").CurrentValue = utcNow;
                        entry.Property("UpdatedDate").CurrentValue = utcNow;
                        break;
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
    public class WebContextFactory : IDesignTimeDbContextFactory<BanHangContext>
    {
        public BanHangContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "Infrastructure"))
            .AddJsonFile("appsettings.json")
            .Build();
            return new BanHangContext(configuration);
        }
    }
}
