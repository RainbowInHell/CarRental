using CarRental.BLL.DTO.VehicleViews;

namespace CarRental.BLL.Contracts
{
    public interface IVehicleService
    {
        public Task<IEnumerable<VehicleWithModelDTO>> GetVehicles();
        public Task<IEnumerable<VehicleWithModelDTO>> GetUnRentedVehicles();
        public Task<VehicleWithModelDTO> GetVehicleById(int id);
        public Task CreateVehicle(VehicleDTO vehicleDTO);
        public Task UpdateVehicle(VehicleDTO vehicleDTO);
        public Task DeleteVehicle(VehicleDTO vehicleDTO);
    }
}
