using Car_Rental.DLL.Entities;
using CarRental.DLL.Interfaces;

namespace CarRental.DLL.Repositories
{
    public class VehicleModelRepository : GenericRepository<VehicleModel>, IVehicleModelRepository
    {
        private readonly CarRentalContext context = null;

        public VehicleModelRepository(CarRentalContext context) : base(context)
        { }

        public IEnumerable<VehicleModel> GetMileageInBetween(int mileageFrom, int mileageTo)
        {
            return context.VehicleModels.AsEnumerable().Where(x => x.Mileage >= mileageFrom && x.Mileage <= mileageTo);
        }
    }
}