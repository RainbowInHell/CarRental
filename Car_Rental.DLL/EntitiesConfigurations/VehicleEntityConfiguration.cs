using Car_Rental.DLL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DLL.EntitiesConfigurations 
{
    public class VehicleEntityConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> vehicleEntityBuilder)
        {
            vehicleEntityBuilder
                .HasKey(e => e.VehicleID);

            vehicleEntityBuilder
                .Property(e => e.IsRented)
                .HasColumnType("boolean")
                .IsRequired();

            vehicleEntityBuilder
                .HasOne(e => e.VehicleModel)
                .WithMany(e => e.Vehicles)
                .HasForeignKey(e => e.VehicleModelID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}