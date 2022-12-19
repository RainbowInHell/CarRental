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

        public IEnumerable<Manufacturer> GetManufacturersWithModels()
        {
            return context.Manufacturers
                          .Include(x => x.VehicleModels)
                          .Where(x => x.VehicleModels.Any())
                          .ToList();
        }
    }
}