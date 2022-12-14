using Car_Rental.DLL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.DLL.EntitiesConfigurations
{
    public class ManufacturerEntityConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> manufacturerEntityBuilder)
        {
            manufacturerEntityBuilder.HasKey(e => e.ManufacturerID);
            manufacturerEntityBuilder.Property(e => e.Name).HasColumnType("varchar").HasMaxLength(25).IsRequired();

            manufacturerEntityBuilder.HasMany(e => e.VehicleModels).WithOne(e => e.Manufacturer);
        }
    }
}