using CarRental.BLL.DTO.VehicleModelViews;
using CarRental.DLL.Entities;

namespace CarRental.BLL.DTO.VehicleView
{
    public class VehicleDTO
    {
        public int Id { get; set; }
        public bool IsRented { get; set; }
        public int RegitrationNumber { get; set; }
        public VehicleModelWithManufacturerDTO VehicleModel { get; set; }

        public static explicit operator VehicleDTO(Vehicle vehicle)
        {
            return vehicle == null ? null : new VehicleDTO
            {
                Id = vehicle.Id,
                IsRented = vehicle.IsRented,
                RegitrationNumber = vehicle.RegistrationNumber,
                VehicleModel = (VehicleModelWithManufacturerDTO)vehicle.VehicleModel
            };
        }

        //TODO
        //public static explicit operator Vehicle(VehicleDTO vehicleDTO)
        //{
        //    return vehicleDTO == null ? null : new Vehicle
        //    {
        //        Id = vehicleDTO.Id,
        //        IsRented = vehicleDTO.IsRented,
        //        RegistrationNumber = vehicleDTO.RegitrationNumber,
        //        VehicleModel = (VehicleModel)vehicleDTO.VehicleModel
        //    };
        //}
    }
}