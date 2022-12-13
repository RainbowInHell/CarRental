namespace Car_Rental.DLL.Entities
{
    public enum BookingStatus { Closed, Active };

    public class Booking
    {
        public int BookingID { get; set; }
        public DateOnly PickUpDate { get; set; }
        public DateOnly PickOffDate { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public int CustomerID { get; set; }
        public int VehicleID { get; set; }

    }
}
