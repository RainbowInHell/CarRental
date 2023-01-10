using CarRental.BLL.DTO.VehicleModelViews;

namespace CarRental.BLL.Contracts
{
    public interface IVehicleModelService
    {
        public Task<IEnumerable<VehicleModelWithManufacturerDTO>> GetVehicleModels();
        public Task<IEnumerable<VehicleModelWithManufacturerDTO>> GetMileageInBetween(int mileageFrom, int mileageTo);
        public Task<VehicleModelWithManufacturerDTO> GetVehicleModelById(int id);
        public Task CreateVehicleModel(VehicleModelDTO vehicleModelDTO);
        public Task UpdateVehicleModel(VehicleModelDTO vehicleModelDTO);
        public Task DeleteVehicleModel(VehicleModelDTO vehicleModelDTO);
    }
}