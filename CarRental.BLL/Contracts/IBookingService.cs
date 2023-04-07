using CarRental.BLL.DTO.BookingViews;
using CarRental.DLL.Entities;

namespace CarRental.BLL.Contracts
{
    public interface IBookingService
    {
        public Task<IEnumerable<SimpleBookingDTO>> GetBookings();
        public Task<IEnumerable<SimpleBookingDTO>> GetBookingsByStatus(BookingStatus bookingStatus);
        public Task<SimpleBookingDTO> GetBookingById(int id);
        public Task CreateBooking(BookingDTO bookingDTO);
        public Task UpdateBooking(BookingDTO bookingDTO);
        public Task DeleteBooking(BookingDTO bookingDTO);
    }
}