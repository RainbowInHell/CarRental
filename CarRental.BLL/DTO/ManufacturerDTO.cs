using CarRental.DLL.Entities;

namespace CarRental.BLL.DTO
{
    public class ManufacturerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static explicit operator ManufacturerDTO(Manufacturer manufacturer)
        {
            return manufacturer == null ? null : new ManufacturerDTO
            {
                Id = manufacturer.Id,
                Name = manufacturer.Name
            };
        }

        public static explicit operator Manufacturer(ManufacturerDTO manufacturer)
        {
            return manufacturer == null ? null : new Manufacturer
            {
                Id = manufacturer.Id,
                Name = manufacturer.Name
            };
        }
    }
}