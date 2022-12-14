using Car_Rental.DLL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.DLL.EntitiesConfigurations
{
    public class BookingEntityConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> bookingEntitybuilder)
        {
            bookingEntitybuilder.HasKey(e => e.BookingID);

            bookingEntitybuilder.Property(e => e.PickUpDate);
            bookingEntitybuilder.Property(e => e.PickOffDate);
            bookingEntitybuilder.Property(e => e.Status);

            bookingEntitybuilder.HasOne(e => e.Customer).WithMany(e => e.Bookings).HasForeignKey(e => e.CustomerID).OnDelete(DeleteBehavior.Cascade);
            bookingEntitybuilder.HasOne(a => a.Vehicle).WithOne(b => b.Booking).HasForeignKey<Vehicle>(b => b.VehicleID);
        }
    }
}
