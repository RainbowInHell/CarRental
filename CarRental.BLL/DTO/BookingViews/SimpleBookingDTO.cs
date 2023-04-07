using CarRental.BLL.DTO.CustomerViews;
using CarRental.BLL.DTO.VehicleViews;
using CarRental.DLL.Entities;

namespace CarRental.BLL.DTO.BookingViews
{
    public class SimpleBookingDTO
    {
        public int Id { get; set; }
        public DateOnly PickUpDate { get; set; }
        public DateOnly PickOffDate { get; set; }
        public BookingStatus Status { get; set; }
        public SimpleCustomerDTO Customer { get; set; }
        public VehicleWithModelDTO Vehicle { get; set; }

        public static explicit operator SimpleBookingDTO(Booking booking)
        {
            return booking == null ? null : new SimpleBookingDTO
            {
                Id = booking.Id,
                PickUpDate = booking.PickUpDate,
                PickOffDate = booking.PickUpDate,
                Status = booking.Status,
                Customer = (SimpleCustomerDTO)booking.Customer,
                Vehicle = (VehicleWithModelDTO)booking.Vehicle
            };
        }
    }
}