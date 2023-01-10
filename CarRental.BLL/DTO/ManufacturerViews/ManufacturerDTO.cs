using CarRental.DLL.Entities;

namespace CarRental.BLL.DTO.ManufacturerViews
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

        public static explicit operator Manufacturer(ManufacturerDTO manufacturerDTO)
        {
            return manufacturerDTO == null ? null : new Manufacturer
            {
                Id = manufacturerDTO.Id,
                Name = manufacturerDTO.Name
            };
        }
    }
}