using Car_Rental.DLL.Entities;
using CarRental.DLL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DLL.Repositories
{
    public class VehicleRepository : GenericRepository<Vehicle>, IVehiclesRepository
    {
        public VehicleRepository(CarRentalContext context) : base(context)
        { }

        public IEnumerable<Vehicle> GetUnRentedVehicles()
        {
            return context.Vehicles
                          .AsNoTracking()
                          .AsEnumerable()
                          .Where(x => !x.IsRented)
                          .ToList();
        }
    }
}