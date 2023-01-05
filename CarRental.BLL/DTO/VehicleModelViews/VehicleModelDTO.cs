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

        public static explicit operator VehicleModel(VehicleModelDTO vehicleModel)
        {
            return vehicleModel == null ? null : new VehicleModel
            {
                Id = vehicleModel.Id,
                Name = vehicleModel.Name,
                Mileage = vehicleModel.Mileage,
                CreatedYear = vehicleModel.CreatedYear,
                ManufacturerID = vehicleModel.ManufacturerId
            };
        }
    }
}