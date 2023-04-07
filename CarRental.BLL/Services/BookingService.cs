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

        public async Task<IEnumerable<SimpleBookingDTO>> GetBookings()
        {
            var bookings = await _unitOfWork.BookingRepository.GetAllAsync();

            return bookings.Select(b => (SimpleBookingDTO)b);
        }

        public async Task<IEnumerable<SimpleBookingDTO>> GetBookingsByStatus(BookingStatus bookingStatus)
        {
            var bookings = await _unitOfWork.BookingRepository.GetBookingsByStatus(bookingStatus);

            return bookings.Select(b => (SimpleBookingDTO)b);
        }

        public async Task<SimpleBookingDTO> GetBookingById(int id)
        {
            var booking = await _unitOfWork.BookingRepository.GetByIdAsync(id);

            return (SimpleBookingDTO)booking;
        }

        public async Task CreateBooking(BookingDTO bookingDTO)
        {
            await _unitOfWork.BookingRepository.CreateAsync((Booking)bookingDTO);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateBooking(BookingDTO bookingDTO)
        {
            _unitOfWork.BookingRepository.Update((Booking)bookingDTO);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteBooking(BookingDTO bookingDTO)
        {
            _unitOfWork.BookingRepository.Delete((Booking)bookingDTO);
            await _unitOfWork.SaveAsync();
        }
    }
}