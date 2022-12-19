using Car_Rental.DLL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.DLL.EntitiesConfigurations
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> customerEntityBuilder)
        {
            customerEntityBuilder
                .HasKey(x => x.Id);

            customerEntityBuilder
                .Property(x => x.Name)
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired();
            
            customerEntityBuilder
                .Property(x => x.Surname)
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired();

            customerEntityBuilder
                .Property(x => x.Email)
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .IsRequired();

            customerEntityBuilder
                .Property(x => x.ContactNumber)
                .HasColumnType("varchar")
                .HasMaxLength(13).IsRequired();

            customerEntityBuilder
                .Property(x => x.PassportNumber)
                .HasColumnType("varchar")
                .HasMaxLength(14)
                .IsRequired();
            
            customerEntityBuilder
                .Property(x => x.Adres)
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .IsRequired();
            
            customerEntityBuilder
                .Property(x => x.DrivingLicenseNumber)
                .HasColumnType("varchar")
                .HasMaxLength(15)
                .IsRequired();

            customerEntityBuilder
                .HasMany(b => b.Bookings)
                .WithOne(c => c.Customer);
        }
    }
}