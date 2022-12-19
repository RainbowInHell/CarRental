using Car_Rental.DLL.Entities;

namespace CarRental.DLL.Interfaces
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        IEnumerable<Booking> GetBookingsByStatus(BookingStatus status);
    }
}