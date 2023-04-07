using CarRental.DLL.Entities;

namespace CarRental.BLL.DTO.ManufacturerViews
{
    public class ManufacturerWithModelsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<string> Models { get; set; }

        public static explicit operator ManufacturerWithModelsDTO(Manufacturer manufacturer)
        {
            return manufacturer == null ? null : new ManufacturerWithModelsDTO
            {
                Id = manufacturer.Id,
                Name = manufacturer.Name,
                Models = manufacturer.VehicleModels.Select(x => x.Name).ToList()
            };
        }
    }
}