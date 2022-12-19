using Car_Rental.DLL.Entities;

namespace CarRental.DLL.Interfaces
{
    public interface IVehicleModelRepository : IGenericRepository<VehicleModel>
    {
        IEnumerable<VehicleModel> GetMileageInBetween(int mileageFrom, int mileageTo);
    }
}