using NancyApp.Common.Entities;
using System.Data.Entity;

namespace NancyApp.DAL
{
    public class NancyDbContext : DbContext
    {
        public NancyDbContext()
            : base("NancyDb")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.ProxyCreationEnabled = true;
        }

        public DbSet<Vehicle> Vehicles;

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Vehicle>().ToTable("Vehicles");
        }
    }
}
