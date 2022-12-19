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
                .HasKey(x => x.Id);

            vehicleEntityBuilder
                .Property(x => x.IsRented)
                .HasColumnType("boolean")
                .IsRequired();

            vehicleEntityBuilder
                .HasOne(vm => vm.VehicleModel)
                .WithMany(v => v.Vehicles)
                .HasForeignKey(vm => vm.VehicleModelID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}