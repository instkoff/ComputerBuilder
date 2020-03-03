using ComputerBuilder.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComputerBuilder.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<CompatibilityPropertyEntity> CompatibilityProperties { get; set; }
        public DbSet<ComputerBuildEntity> ComputerBuilds { get; set; }
        public DbSet<HardwareItemEntity> HardwareItems { get; set; }
        public DbSet<HardwareTypeEntity> HardwareTypes { get; set; }
        public DbSet<ManufacturerEntity> Manufacturers { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ManufacturerEntity>().HasIndex(n => n.Name).IsUnique();
            modelBuilder.Entity<HardwareTypeEntity>().HasIndex(n => n.Name).IsUnique();
            modelBuilder.Entity<HardwareItemEntity>().HasIndex(n => n.Name).IsUnique();
            modelBuilder.Entity<CompatibilityPropertyEntity>().HasIndex(n => n.PropertyName).IsUnique();
            modelBuilder.Entity<UserEntity>().HasIndex(n => n.Username).IsUnique();

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

            modelBuilder.Entity<CompatibilityPropertyHardwareItem>()
                .HasKey(t => new { t.HardwareItemId, t.CompatibilityPropertyId });

            modelBuilder.Entity<CompatibilityPropertyHardwareItem>()
                .HasOne(hi => hi.HardwareItem)
                .WithMany(pi => pi.PropertiesItems)
                .HasForeignKey(fk=>fk.HardwareItemId);

            modelBuilder.Entity<CompatibilityPropertyHardwareItem>()
                .HasOne(cp => cp.CompatibilityProperty)
                .WithMany(pi => pi.PropertiesItems)
                .HasForeignKey(fk=>fk.CompatibilityPropertyId);
        }


    }
}
