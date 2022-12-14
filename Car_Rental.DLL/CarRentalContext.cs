using Car_Rental.DLL.Entities;
using CarRental.DLL.EntitiesConfigurations;
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

        public CarRentalContext() 
        { }
        
        public CarRentalContext(DbContextOptions<CarRentalContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new ManufacturerEntityConfiguration().Configure(modelBuilder.Entity<Manufacturer>());
            new VehicleModelEntityConfiguration().Configure(modelBuilder.Entity<VehicleModel>());
            new VehicleEntityConfiguration().Configure(modelBuilder.Entity<Vehicle>());
            new CustomerEntityConfiguration().Configure(modelBuilder.Entity<Customer>());
            new BookingEntityConfiguration().Configure(modelBuilder.Entity<Booking>());
        }
    }
}
