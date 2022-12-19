using Car_Rental.DLL.Entities;
using CarRental.DLL.Interfaces;

namespace CarRental.DLL.Repositories
{
    public class VehicleRepository : GenericRepository<Vehicle>, IVehiclesRepository
    {
        private readonly CarRentalContext context = null;

        public VehicleRepository(CarRentalContext context) : base(context)
        { }

        public IEnumerable<Vehicle> GetUnRentedVehicles()
        {
            return context.Vehicles.AsEnumerable().Where(x => !x.IsRented);
        }
    }
}