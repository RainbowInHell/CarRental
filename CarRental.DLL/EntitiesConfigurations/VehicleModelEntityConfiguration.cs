using CarRental.DLL.Entities;
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
                .HasIndex(m => m.Name)
                .IsUnique();

            vehicleModelEntityBuilder
                .Property(x => x.Name)
                .HasMaxLength(25)
                .IsRequired();

            vehicleModelEntityBuilder
                .Property(x => x.Mileage)
                .IsRequired();

            vehicleModelEntityBuilder
                .Property(x => x.CreatedYear)
                .IsRequired();

            vehicleModelEntityBuilder
                .HasOne(m => m.Manufacturer)
                .WithMany(vm => vm.VehicleModels)
                .HasForeignKey(m => m.ManufacturerID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}