using CarRental.DLL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DLL
{
    public class CarRentalContext : DbContext
    {
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public CarRentalContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarRentalContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}