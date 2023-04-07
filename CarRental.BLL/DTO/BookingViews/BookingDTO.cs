using CarRental.BLL.DTO.CustomerViews;
using CarRental.BLL.DTO.VehicleViews;
using CarRental.DLL.Entities;

namespace CarRental.BLL.DTO.BookingViews
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public DateOnly PickUpDate { get; set; }
        public DateOnly PickOffDate { get; set; }
        public BookingStatus Status { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }

        public static explicit operator Booking(BookingDTO bookingDTO)
        {
            return bookingDTO == null ? null : new Booking
            {
                Id = bookingDTO.Id,
                PickUpDate = bookingDTO.PickUpDate,
                PickOffDate = bookingDTO.PickOffDate,
                Status = bookingDTO.Status,
                CustomerID = bookingDTO.CustomerId,
                VehicleID = bookingDTO.VehicleId
            };
        }

        public static explicit operator BookingDTO(Booking booking)
        {
            return booking == null ? null : new BookingDTO
            {
                Id = booking.Id,
                PickUpDate = booking.PickUpDate,
                PickOffDate = booking.PickOffDate,
                Status = booking.Status,
                CustomerId = booking.CustomerID,
                VehicleId = booking.VehicleID
            };
        }
    }
}