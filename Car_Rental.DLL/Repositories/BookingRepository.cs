using Car_Rental.DLL.Entities;
using CarRental.DLL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DLL.Repositories
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(CarRentalContext context) : base(context)
        { }

        public IEnumerable<Booking> GetBookingsByStatus(BookingStatus status)
        {
            return context.Bookings
                          .AsNoTracking()
                          .AsEnumerable()
                          .Where(x => x.Status == status)
                          .ToList();
        }
    }
}