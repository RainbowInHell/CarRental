using Car_Rental.DLL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace CarRental.DLL.EntitiesConfigurations
{
    public class VehicleModelEntityConfiguration : IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> vehicleModelEntityBuilder)
        {
            vehicleModelEntityBuilder.HasKey(e => e.VehicleModelID);

            vehicleModelEntityBuilder.Property(e => e.Name).HasColumnType("varchar").HasMaxLength(25).IsRequired();
            vehicleModelEntityBuilder.Property(e => e.Mileage).HasColumnType("integer").IsRequired();
            vehicleModelEntityBuilder.Property(e => e.CreatedYear).HasColumnType("integer").IsRequired();

            vehicleModelEntityBuilder.HasOne(e => e.Manufacturer).WithMany(e => e.VehicleModels).HasForeignKey(e => e.ManufacturerID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}