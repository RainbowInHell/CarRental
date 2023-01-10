using CarRental.BLL.DTO.ManufacturerViews;
using CarRental.DLL.Entities;

namespace CarRental.BLL.DTO.VehicleModelViews
{
    public class VehicleModelWithManufacturerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Mileage { get; set; }
        public int CreatedYear { get; set; }
        public ManufacturerDTO Manufacturer { get; set; }

        public static explicit operator VehicleModelWithManufacturerDTO(VehicleModel vehicleModel)
        {
            return vehicleModel == null ? null : new VehicleModelWithManufacturerDTO
            {
                Id = vehicleModel.Id,
                Name = vehicleModel.Name,
                Mileage = vehicleModel.Mileage,
                CreatedYear = vehicleModel.CreatedYear,
                Manufacturer = (ManufacturerDTO)vehicleModel.Manufacturer
            };
        }

        public static explicit operator VehicleModel(VehicleModelWithManufacturerDTO vehicleModelWithManufacturerDTO)
        {
            return vehicleModelWithManufacturerDTO == null ? null : new VehicleModel
            {
                Id = vehicleModelWithManufacturerDTO.Id,
                Name = vehicleModelWithManufacturerDTO.Name,
                Mileage = vehicleModelWithManufacturerDTO.Mileage,
                CreatedYear = vehicleModelWithManufacturerDTO.CreatedYear,
                Manufacturer = (Manufacturer)vehicleModelWithManufacturerDTO.Manufacturer
            };
        }
    }
}