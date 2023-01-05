using CarRental.BLL.DTO.VehicleView;

namespace CarRental.BLL.Contracts
{
    public interface IVehicleService
    {
        public Task<IEnumerable<VehicleDTO>> GetVehicles();
        //public Task<IEnumerable<VehicleDTO>> GetUnRentedVehicles();
        //public Task<VehicleDTO> GetVehicleById(int id);
        //public Task CreateVehicle(VehicleDTO vehicleDTO);
        //public Task UpdateVehicle(VehicleDTO vehicleDTO);
        //public Task DeleteVehicle(VehicleDTO vehicleDTO);
    }
}
