using Car_Rental.DLL.Entites;
using Car_Rental.DLL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CarRental.DLL
{
    public class CarRentalContext : DbContext
    {
        public CarRentalContext() 
        { }
        
        public CarRentalContext(DbContextOptions<CarRentalContext> options) : base(options)
        { }

        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("manufacturers");
                
                entity.HasKey(e => e.ManufacturerID);
                entity.Property(e => e.ManufacturerName).HasMaxLength(25).IsRequired();

            });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            
            IConfiguration configuration = builder.Build();
            
            var myConnectionString1 = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseNpgsql(myConnectionString1);
        }
    }
}
