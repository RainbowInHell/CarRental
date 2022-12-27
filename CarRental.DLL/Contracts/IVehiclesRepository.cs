using Car_Rental.DLL.Entities;

namespace CarRental.DLL.Contracts
{
    public interface IVehiclesRepository : IGenericRepository<Vehicle>
    {
        Task<IEnumerable<Vehicle>> GetUnRentedVehicles();
    }
}