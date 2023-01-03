using CarRental.BLL.DTO;

namespace CarRental.BLL.Contracts
{
    public interface IVehicleModelService
    {
        public Task<IEnumerable<VehicleModelDTO>> GetVehicleModels();

    }
}