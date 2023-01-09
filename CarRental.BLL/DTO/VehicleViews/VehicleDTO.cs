using CarRental.DLL.Entities;

namespace CarRental.BLL.DTO.VehicleViews
{
    public class VehicleDTO
    {
        public int Id { get; set; }
        public bool IsRented { get; set; }
        public int RegitrationNumber { get; set; }
        public int VehicleModelId { get; set; }

        public static explicit operator Vehicle(VehicleDTO vehicleDTO)
        {
            return vehicleDTO == null ? null : new Vehicle
            {
                Id = vehicleDTO.Id,
                IsRented = vehicleDTO.IsRented,
                RegistrationNumber = vehicleDTO.RegitrationNumber,
                VehicleModelID = vehicleDTO.VehicleModelId
            };
        }
    }
}