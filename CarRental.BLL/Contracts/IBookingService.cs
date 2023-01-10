using CarRental.BLL.DTO.BookingViews;
using CarRental.DLL.Entities;

namespace CarRental.BLL.Contracts
{
    public interface IBookingService
    {
        public Task<IEnumerable<BookingDTO>> GetBookings();
        public Task<IEnumerable<BookingDTO>> GetBookingsByStatus(BookingStatus bookingStatus);
        public Task<BookingDTO> GetBookingById(int id);
        public Task CreateBooking(BookingDTO customerDTO);
        public Task UpdateBooking(BookingDTO customerDTO);
        public Task DeleteBooking(BookingDTO CustomerDTO);
    }
}