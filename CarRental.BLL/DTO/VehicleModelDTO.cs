using CarRental.DLL.Entities;

namespace CarRental.BLL.DTO
{
    public class VehicleModelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Mileage { get; set; }
        public int CreatedYear { get; set; }
        public ManufacturerDTO Manufacturer { get; set; }

        public static explicit operator VehicleModelDTO(VehicleModel vehicleModel)
        {
            return vehicleModel == null ? null : new VehicleModelDTO
            {
                Id = vehicleModel.Id,
                Name = vehicleModel.Name,
                Mileage = vehicleModel.Mileage,
                CreatedYear = vehicleModel.CreatedYear,
                Manufacturer = (ManufacturerDTO)vehicleModel.Manufacturer
            };
        }

        public static explicit operator VehicleModel(VehicleModelDTO vehicleModel)
        {
            return vehicleModel == null ? null : new VehicleModel
            {
                Id = vehicleModel.Id,
                Name = vehicleModel.Name,
                Mileage = vehicleModel.Mileage,
                CreatedYear = vehicleModel.CreatedYear,
                Manufacturer = (Manufacturer)vehicleModel.Manufacturer
            };
        }
    }
}