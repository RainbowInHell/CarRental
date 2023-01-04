using CarRental.BLL.DTO;

namespace CarRental.BLL.Contracts
{
    public interface IVehicleModelService
    {
        public Task<IEnumerable<VehicleModelDTO>> GetVehicleModels();
        public Task<IEnumerable<VehicleModelDTO>> GetMileageInBetween(int mileageFrom, int mileageTo);
        public Task<VehicleModelDTO> GetVehicleModelById(int id);
        public Task CreateVehicleModel(VehicleModelDTO vehicleModel);
        public Task UpdateVehicleModel(VehicleModelDTO vehicleModel);
        public Task DeleteVehicleModel(VehicleModelDTO vehicleModel);
    }
}