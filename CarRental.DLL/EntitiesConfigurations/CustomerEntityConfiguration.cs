using CarRental.DLL.Entities;
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
                .HasMaxLength(25)
                .IsRequired();

            customerEntityBuilder
                .Property(x => x.Surname)
                .HasMaxLength(25)
                .IsRequired();

            customerEntityBuilder
                .Property(x => x.Email)
                .HasMaxLength(40)
                .IsRequired();

            customerEntityBuilder
                .Property(x => x.ContactNumber)
                .HasMaxLength(13)
                .IsRequired();

            customerEntityBuilder
                .Property(x => x.PassportNumber)
                .HasMaxLength(14)
                .IsRequired();

            customerEntityBuilder
                .Property(x => x.Adres)
                .HasMaxLength(40)
                .IsRequired();

            customerEntityBuilder
                .Property(x => x.DrivingLicenseNumber)
                .HasMaxLength(15)
                .IsRequired();

            customerEntityBuilder
                .HasMany(b => b.Bookings)
                .WithOne(c => c.Customer);
        }
    }
}