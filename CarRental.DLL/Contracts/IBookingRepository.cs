using CarRental.DLL.Entities;

namespace CarRental.DLL.Contracts
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetBookingsByStatus(BookingStatus status);
    }
}