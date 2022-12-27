using Car_Rental.DLL.Entities;
using CarRental.DLL.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DLL.Repositories
{
    public class VehicleRepository : GenericRepository<Vehicle>, IVehiclesRepository
    {
        public VehicleRepository(CarRentalContext context) : base(context)
        { }

        public async Task<IEnumerable<Vehicle>> GetUnRentedVehicles()
        {
            return await _context.Vehicles
                          .AsNoTracking()
                          .Where(x => !x.IsRented)
                          .ToListAsync();
        }
    }
}