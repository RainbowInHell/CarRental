namespace Car_Rental.DLL.Entities
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public bool IsRented { get; set; }

        public int VehicleModelID { get; set; }
        public VehicleModel VehicleModel { get; set; }

        public Booking Booking { get; set; }
    }
}