using CarRental.DLL.Entities;
using CarRental.DLL.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DLL.Repositories
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(CarRentalContext context) : base(context)
        { }

        public async Task<IEnumerable<Booking>> GetBookingsByStatus(BookingStatus status)
        {
            return await _context.Bookings
                .Where(x => x.Status == status)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}