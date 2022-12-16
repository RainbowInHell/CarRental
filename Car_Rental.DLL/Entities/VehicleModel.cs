using CarRental.DLL.Entities;

namespace Car_Rental.DLL.Entities
{
    public class VehicleModel : BaseEntity
    {
        //public int VehicleModelID { get; set; }
        public new int Id { get; set; }
        public string Name { get; set; }
        public int Mileage { get; set; }
        public int CreatedYear { get; set; }

        public int ManufacturerID { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}