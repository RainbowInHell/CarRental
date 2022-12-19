using Car_Rental.DLL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.DLL.EntitiesConfigurations
{
    public class VehicleModelEntityConfiguration : IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> vehicleModelEntityBuilder)
        {
            vehicleModelEntityBuilder
                .HasKey(x => x.Id);

            vehicleModelEntityBuilder
                .Property(x => x.Name)
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired();

            vehicleModelEntityBuilder
                .Property(x => x.Mileage)
                .HasColumnType("integer")
                .IsRequired();

            vehicleModelEntityBuilder
                .Property(x => x.CreatedYear)
                .HasColumnType("integer")
                .IsRequired();

            vehicleModelEntityBuilder
                .HasOne(m => m.Manufacturer)
                .WithMany(vm => vm.VehicleModels)
                .HasForeignKey(m => m.ManufacturerID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}