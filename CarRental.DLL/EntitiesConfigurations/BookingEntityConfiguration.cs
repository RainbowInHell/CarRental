using Car_Rental.DLL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.DLL.EntitiesConfigurations
{
    public class BookingEntityConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> bookingEntitybuilder)
        {
            bookingEntitybuilder
                .HasKey(x => x.Id);

            bookingEntitybuilder
                .Property(x => x.PickUpDate);

            bookingEntitybuilder
                .Property(x => x.PickOffDate);

            bookingEntitybuilder
                .Property(x => x.Status);

            bookingEntitybuilder
                .HasOne(x => x.Customer)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x => x.CustomerID)
                .OnDelete(DeleteBehavior.Cascade);

            bookingEntitybuilder
                .HasOne(v => v.Vehicle)
                .WithOne(b => b.Booking)
                .HasForeignKey<Vehicle>(b => b.Id);
        }
    }
}