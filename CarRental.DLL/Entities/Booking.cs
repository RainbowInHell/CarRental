namespace CarRental.DLL.Entities
{
    public enum BookingStatus { Closed, Active };

    public class Booking : BaseEntity
    {
        public override int Id { get; set; }
        public DateOnly PickUpDate { get; set; }
        public DateOnly PickOffDate { get; set; }
        public BookingStatus Status { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public int VehicleID { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}