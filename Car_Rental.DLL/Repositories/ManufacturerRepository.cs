using Car_Rental.DLL.Entities;
using CarRental.DLL.Interfaces;
using CarRental.DLL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DLL.Repository
{
    public class ManufacturerRepository : GenericRepository<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(CarRentalContext context) : base(context)
        { }

        public async Task<IEnumerable<Manufacturer>> GetManufacturersWithModels()
        {
            return await context.Manufacturers
                                .Include(x => x.VehicleModels)
                                .Where(x => x.VehicleModels.Any())
                                .ToListAsync();
        }
    }
}