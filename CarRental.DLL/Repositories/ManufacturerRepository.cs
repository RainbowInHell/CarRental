using CarRental.DLL.Contracts;
using CarRental.DLL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DLL.Repositories
{
    public class ManufacturerRepository : GenericRepository<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(CarRentalContext context) : base(context)
        { }

        public async Task<IEnumerable<Manufacturer>> GetManufacturersWithModels()
        {
            return await _context.Manufacturers
                .AsNoTracking()
                .Include(x => x.VehicleModels)
                .Where(x => x.VehicleModels.Any())
                .ToListAsync();
        }
    }
}