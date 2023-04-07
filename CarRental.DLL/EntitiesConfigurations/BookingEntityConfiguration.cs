using CarRental.DLL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.DLL.EntitiesConfigurations
{
    public class BookingEntityConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> bookingEntityBuilder)
        {
            bookingEntityBuilder
                .HasKey(x => x.Id);

            bookingEntityBuilder
                .Property(x => x.PickUpDate);

            bookingEntityBuilder
                .Property(x => x.PickOffDate);

            bookingEntityBuilder
                .Property(x => x.Status);

            bookingEntityBuilder
                .HasOne(x => x.Customer)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x => x.CustomerID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}