using Car_Rental.DLL.Entities;

namespace CarRental.DLL.Interfaces
{
    public interface IVehiclesRepository : IGenericRepository<Vehicle>
    {
        IEnumerable<Vehicle> GetUnRentedVehicles();
    }
}