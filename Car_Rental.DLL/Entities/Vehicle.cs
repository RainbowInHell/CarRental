using CarRental.DLL.Entities;

namespace Car_Rental.DLL.Entities
{
    public class Vehicle : BaseEntity
    {
        public new int Id { get; set; }
        public bool IsRented { get; set; }

        public int VehicleModelID { get; set; }
        public VehicleModel VehicleModel { get; set; }

        public Booking Booking { get; set; }
    }
}