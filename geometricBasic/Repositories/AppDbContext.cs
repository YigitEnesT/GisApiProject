using geometricBasic.Models;
using geometricBasic.Repositories.Config;
using Microsoft.EntityFrameworkCore;

namespace geometricBasic.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<GeoPoint> GeoPoints{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GeoPointConfig());
        }
    }
}
