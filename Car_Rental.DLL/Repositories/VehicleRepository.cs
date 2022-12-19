using Car_Rental.DLL.Entities;
using CarRental.DLL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DLL.Repositories
{
    public class VehicleRepository : GenericRepository<Vehicle>, IVehiclesRepository
    {
        public VehicleRepository(CarRentalContext context) : base(context)
        { }

        public async Task<IEnumerable<Vehicle>> GetUnRentedVehicles()
        {
            return await context.Vehicles
                          .AsNoTracking()
                          .Where(x => !x.IsRented)
                          .ToListAsync();
        }
    }
}