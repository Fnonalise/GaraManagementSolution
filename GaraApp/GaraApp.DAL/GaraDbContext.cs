using GaraApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace GaraApp.DAL
{
    public class GaraDbContext : DbContext
    {
        public GaraDbContext(DbContextOptions<GaraDbContext> options) : base(options) { }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Car> Cars => Set<Car>();
        public DbSet<Part> Parts => Set<Part>();
        public DbSet<Service> Services => Set<Service>();
        public DbSet<RepairOrder> RepairOrders => Set<RepairOrder>();
        public DbSet<RepairServiceDetail> RepairServiceDetails => Set<RepairServiceDetail>();
        public DbSet<RepairPartDetail> RepairPartDetails => Set<RepairPartDetail>();
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasIndex(x => x.LicensePlate)
                .IsUnique();

            modelBuilder.Entity<Customer>()
                .Property(x => x.FullName).HasMaxLength(200);

            modelBuilder.Entity<Car>()
                .Property(x => x.LicensePlate).HasMaxLength(20);

            modelBuilder.Entity<User>()
                .HasIndex(x => x.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(x => x.Username).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.Password).HasMaxLength(255).IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.FullName).HasMaxLength(200);

            modelBuilder.Entity<User>()
                .Property(x => x.Role).HasMaxLength(20).HasDefaultValue("User");

            // decimal precision
            modelBuilder.Entity<Part>().Property(x => x.UnitPrice).HasPrecision(18, 2);
            modelBuilder.Entity<Service>().Property(x => x.BasePrice).HasPrecision(18, 2);
            modelBuilder.Entity<RepairOrder>().Property(x => x.TotalAmount).HasPrecision(18, 2);
            modelBuilder.Entity<RepairServiceDetail>().Property(x => x.UnitPrice).HasPrecision(18, 2);
            modelBuilder.Entity<RepairServiceDetail>().Property(x => x.LineTotal).HasPrecision(18, 2);
            modelBuilder.Entity<RepairPartDetail>().Property(x => x.UnitPrice).HasPrecision(18, 2);
            modelBuilder.Entity<RepairPartDetail>().Property(x => x.LineTotal).HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
