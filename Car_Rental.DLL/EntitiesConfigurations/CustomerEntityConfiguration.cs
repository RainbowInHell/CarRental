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
                .HasKey(e => e.CustomerID);

            customerEntityBuilder
                .Property(e => e.Name)
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired();
            
            customerEntityBuilder
                .Property(e => e.Surname)
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired();

            customerEntityBuilder
                .Property(e => e.Email)
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .IsRequired();

            customerEntityBuilder
                .Property(e => e.ContactNumber)
                .HasColumnType("varchar")
                .HasMaxLength(13).IsRequired();

            customerEntityBuilder
                .Property(e => e.PassportNumber)
                .HasColumnType("varchar")
                .HasMaxLength(14)
                .IsRequired();
            
            customerEntityBuilder
                .Property(e => e.Adres)
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .IsRequired();
            
            customerEntityBuilder
                .Property(e => e.DrivingLicenseNumber)
                .HasColumnType("varchar")
                .HasMaxLength(15)
                .IsRequired();

            customerEntityBuilder
                .HasMany(e => e.Bookings)
                .WithOne(e => e.Customer);
        }
    }
}