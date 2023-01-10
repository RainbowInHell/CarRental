using CarRental.DLL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DLL.EntitiesConfigurations
{
    public class VehicleEntityConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> vehicleEntityBuilder)
        {
            vehicleEntityBuilder
                .HasKey(x => x.Id);

            vehicleEntityBuilder
                .Property(x => x.IsRented)
                .IsRequired();

            vehicleEntityBuilder
                .Property(x => x.RegistrationNumber)
                .IsRequired();

            vehicleEntityBuilder
                .HasOne(vm => vm.VehicleModel)
                .WithMany(v => v.Vehicles)
                .HasForeignKey(vm => vm.VehicleModelID)
                .OnDelete(DeleteBehavior.Cascade);

            vehicleEntityBuilder
                .HasOne(v => v.Booking)
                .WithOne(b => b.Vehicle)
                .HasForeignKey<Booking>(b => b.VehicleID);
        }
    }
}