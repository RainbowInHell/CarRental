using Car_Rental.DLL.Entities;

namespace CarRental.BLL.DTO
{
    public class ManufacturerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static explicit operator ManufacturerDTO(Manufacturer manufacturer)
        {
            return new ManufacturerDTO
            {
                Id = manufacturer.Id,
                Name = manufacturer.Name
            };
        }
    }
}