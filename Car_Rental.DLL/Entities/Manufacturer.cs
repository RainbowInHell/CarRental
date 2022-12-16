using CarRental.DLL.Entities;

namespace Car_Rental.DLL.Entities
{
    public class Manufacturer : BaseEntity
    {
        //public int ManufacturerID { get; set; }
        public new int Id { get; set; }
        public string Name { get; set; }

        public ICollection<VehicleModel> VehicleModels { get; set; }
    }
}