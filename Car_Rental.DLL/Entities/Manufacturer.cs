namespace Car_Rental.DLL.Entities
{
    public class Manufacturer
    {
        public int ManufacturerID { get; set; }
        public string Name { get; set; }

        public ICollection<VehicleModel> VehicleModels { get; set; }
    }
}