using Car_Rental.DLL.Entities;

namespace CarRental.DLL.Contracts
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetBookingsByStatus(BookingStatus status);
    }
}