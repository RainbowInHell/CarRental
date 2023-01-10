using CarRental.DLL.Entities;
using CarRental.DLL.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DLL.Repositories
{
    public class VehicleModelRepository : GenericRepository<VehicleModel>, IVehicleModelRepository
    {
        public VehicleModelRepository(CarRentalContext context) : base(context)
        { }

        public async Task<IEnumerable<VehicleModel>> GetMileageInBetween(int mileageFrom, int mileageTo)
        {
            return await _context.VehicleModels
                .AsNoTracking()
                .Include(x => x.Manufacturer)
                .Where(x => x.Mileage >= mileageFrom && x.Mileage <= mileageTo)
                .ToListAsync();
        }
    }
}