using CarRental.BLL.Contracts;
using CarRental.BLL.DTO.BookingViews;
using CarRental.DLL.Contracts;
using CarRental.DLL.Entities;

namespace CarRental.BLL.Services
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BookingDTO>> GetBookings()
        {
            var bookings = await _unitOfWork.BookingRepository.GetAllAsync();

            return bookings.Select(b => (BookingDTO)b);
        }

        public Task<IEnumerable<BookingDTO>> GetBookingsByStatus(BookingStatus bookingStatus)
        {
            throw new NotImplementedException();
        }

        public Task<BookingDTO> GetBookingById(int id)
        {
            throw new NotImplementedException();
        }

        public Task CreateBooking(BookingDTO customerDTO)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBooking(BookingDTO customerDTO)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBooking(BookingDTO CustomerDTO)
        {
            throw new NotImplementedException();
        }
    }
}