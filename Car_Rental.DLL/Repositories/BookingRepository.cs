using Car_Rental.DLL.Entities;
using CarRental.DLL.Interfaces;

namespace CarRental.DLL.Repositories
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        private readonly CarRentalContext context = null;

        public BookingRepository(CarRentalContext context) : base(context)
        { }

        public IEnumerable<Booking> GetBookingsByStatus(BookingStatus status)
        {
            return context.Bookings.AsEnumerable().Where(x => x.Status == status);
        }
    }
}