using CarRental.DLL.Entities;

namespace CarRental.BLL.DTO.VehicleModelViews
{
    public class VehicleModelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Mileage { get; set; }
        public int CreatedYear { get; set; }
        public int ManufacturerId { get; set; }

        public static explicit operator VehicleModel(VehicleModelDTO vehicleModelDTO)
        {
            return vehicleModelDTO == null ? null : new VehicleModel
            {
                Id = vehicleModelDTO.Id,
                Name = vehicleModelDTO.Name,
                Mileage = vehicleModelDTO.Mileage,
                CreatedYear = vehicleModelDTO.CreatedYear,
                ManufacturerID = vehicleModelDTO.ManufacturerId
            };
        }

        public static explicit operator VehicleModelDTO(VehicleModel vehicleModelDTO)
        {
            return vehicleModelDTO == null ? null : new VehicleModelDTO
            {
                Id = vehicleModelDTO.Id,
                Name = vehicleModelDTO.Name,
                Mileage = vehicleModelDTO.Mileage,
                CreatedYear = vehicleModelDTO.CreatedYear,
                ManufacturerId = vehicleModelDTO.ManufacturerID
            };
        }
    }
}