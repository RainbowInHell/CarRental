using CarRental.DLL.Contracts;
using CarRental.DLL.Entities;
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
                .Include(x => x.VehicleModel.Manufacturer)
                .Where(x => !x.IsRented)
                .ToListAsync();
        }
    }
}