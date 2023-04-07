using CarRental.BLL.Contracts;
using CarRental.BLL.DTO.BookingViews;
using CarRental.DLL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    /// <summary>
    /// Represents a controller for managing bookings.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        /// <summary>
        /// Gets a list of bookings.
        /// </summary>
        /// <returns>A list of bookings.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBookings()
        {
            var bookings = await _bookingService.GetBookings();

            return !bookings.Any() ? NotFound("The bookings were not found.") : Ok(bookings);
        }

        /// <summary>
        /// Gets bookings by status.
        /// </summary>
        /// <param name="bookingStatus">Status of the bookings to retrieve</param>
        /// <returns>A list of bookings with the specified status.</returns>
        [HttpGet("bookings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBookingsByStatus(BookingStatus bookingStatus)
        {
            var bookings = await _bookingService.GetBookingsByStatus(bookingStatus);

            return !bookings.Any() ? NotFound("The bookings were not found.") : Ok(bookings);
        }

        /// <summary>
        /// Gets a booking by its ID.
        /// </summary>
        /// <param name="id">The ID of the booking to retrieve.</param>
        /// <returns>The booking with the specified id, if it exists; otherwise, a 404 Not Found response.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking = await _bookingService.GetBookingById(id);

            return booking == null ? NotFound("The booking was not found.") : Ok(booking);
        }

        /// <summary>
        /// Creates a new booking.
        /// </summary>
        /// <param name="bookingDTO">The booking to create.</param>
        /// <returns>A 204 No Content response, indicating that the booking was successfully created.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CreateBooking(BookingDTO bookingDTO)
        {
            await _bookingService.CreateBooking(bookingDTO);

            return NoContent();
        }

        /// <summary>
        /// Updates an existing booking.
        /// </summary>
        /// <param name="bookingDTO">The updated data for the booking.</param>
        /// <returns>A 204 No Content response, indicating that the booking was successfully updated.</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateBooking(BookingDTO bookingDTO)
        {
            await _bookingService.UpdateBooking(bookingDTO);

            return NoContent();
        }

        /// <summary>
        /// Deletes an existing booking.
        /// </summary>
        /// <param name="bookingDTO">The booking to delete.</param>
        /// <returns>A 204 No Content response, indicating that the booking was successfully deleted.</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteBookings(BookingDTO bookingDTO)
        {
            await _bookingService.DeleteBooking(bookingDTO);

            return NoContent();
        }
    }
}