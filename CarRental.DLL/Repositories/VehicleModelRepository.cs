using Car_Rental.DLL.Entities;
using CarRental.DLL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DLL.Repositories
{
    public class VehicleModelRepository : GenericRepository<VehicleModel>, IVehicleModelRepository
    {
        public VehicleModelRepository(CarRentalContext context) : base(context)
        { }

        public async Task<IEnumerable<VehicleModel>> GetMileageInBetween(int mileageFrom, int mileageTo)
        {
            if(mileageFrom < 0 || mileageTo < 0 || mileageFrom > mileageTo)
            {
                throw new ArgumentOutOfRangeException();
            }

            return await _context.VehicleModels
                          .AsNoTracking()
                          .Where(x => x.Mileage >= mileageFrom && x.Mileage <= mileageTo)
                          .ToListAsync();
        }
    }
}