using CarRental.DLL.Entities;

namespace CarRental.DLL.Contracts
{
    public interface IVehicleModelRepository : IGenericRepository<VehicleModel>
    {
        Task<IEnumerable<VehicleModel>> GetMileageInBetween(int mileageFrom, int mileageTo);
    }
}