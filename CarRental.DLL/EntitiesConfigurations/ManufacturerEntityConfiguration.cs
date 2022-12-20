using Car_Rental.DLL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.DLL.EntitiesConfigurations
{
    public class ManufacturerEntityConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> manufacturerEntityBuilder)
        {
            manufacturerEntityBuilder
                .HasKey(x => x.Id);

            manufacturerEntityBuilder
                .Property(x => x.Name)
                .HasMaxLength(25)
                .IsRequired();

            manufacturerEntityBuilder
                .HasMany(vm => vm.VehicleModels)
                .WithOne(m => m.Manufacturer);
        }
    }
}