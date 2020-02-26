using ComputerBuilder.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComputerBuilder.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<CompatibilityPropertyEntity> compatibilityProperties { get; set; }
        public DbSet<ComputerBuildEntity> computerBuilds { get; set; }
        public DbSet<HardwareItemEntity> hardwareItems { get; set; }
        public DbSet<HardwareTypeEntity> hardwareTypes { get; set; }
        public DbSet<ManufacturerEntity> manufacturers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComputerBuildHardwareItem>()
                .HasKey(t => new { t.ComputerBuildId, t.HardwareItemId});

            modelBuilder.Entity<ComputerBuildHardwareItem>()
                .HasOne(bi => bi.HardwareItem)
                .WithMany(i => i.BuildItems)
                .HasForeignKey(bi => bi.HardwareItemId);

            modelBuilder.Entity<ComputerBuildHardwareItem>()
                .HasOne(bi => bi.ComputerBuild)
                .WithMany(c => c.BuildItems)
                .HasForeignKey(bi => bi.ComputerBuildId);
        }


    }
}
