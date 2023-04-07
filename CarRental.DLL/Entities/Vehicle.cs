namespace CarRental.DLL.Entities
{
    public class Vehicle : BaseEntity
    {
        public override int Id { get; set; }
        public bool IsRented { get; set; }
        public int RegistrationNumber { get; set; }
        public int VehicleModelID { get; set; }
        public VehicleModel VehicleModel { get; set; }

        public Booking Booking { get; set; }
    }
}