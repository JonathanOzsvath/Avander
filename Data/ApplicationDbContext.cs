using Avander.Models;
using Microsoft.EntityFrameworkCore;

namespace Avander.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Measurement>()
                .Property(b => b.Flush)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Measurement>()
                .Property(b => b.Gap)
                .HasPrecision(8, 2);
        }            

        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<MeasurementPoint> MeasurementPoints { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}