using CarRental.BLL.DTO.VehicleModelViews;
using CarRental.DLL.Entities;

namespace CarRental.BLL.DTO.VehicleViews
{
    public class VehicleWithModelDTO
    {
        public int Id { get; set; }
        public bool IsRented { get; set; }
        public int RegitrationNumber { get; set; }
        public VehicleModelWithManufacturerDTO VehicleModel { get; set; }

        public static explicit operator VehicleWithModelDTO(Vehicle vehicle)
        {
            return vehicle == null ? null : new VehicleWithModelDTO
            {
                Id = vehicle.Id,
                IsRented = vehicle.IsRented,
                RegitrationNumber = vehicle.RegistrationNumber,
                VehicleModel = (VehicleModelWithManufacturerDTO)vehicle.VehicleModel
            };
        }

        public static explicit operator Vehicle(VehicleWithModelDTO vehicleDTO)
        {
            return vehicleDTO == null ? null : new Vehicle
            {
                Id = vehicleDTO.Id,
                IsRented = vehicleDTO.IsRented,
                RegistrationNumber = vehicleDTO.RegitrationNumber,
                VehicleModel = (VehicleModel)vehicleDTO.VehicleModel
            };
        }
    }
}