﻿using CarRental.DLL.Entities;
using CarRental.DLL.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DLL.Repositories
{
    public class VehicleModelRepository : GenericRepository<VehicleModel>, IVehicleModelRepository
    {
        public VehicleModelRepository(CarRentalContext context) : base(context)
        { }

        public override async Task<IEnumerable<VehicleModel>> GetAllAsync()
        {
            return await _context.VehicleModels
                .AsNoTracking()
                .Include(x => x.Manufacturer)
                .ToListAsync();
        }

        public async Task<IEnumerable<VehicleModel>> GetMileageInBetween(int mileageFrom, int mileageTo)
        {
            if (mileageFrom < 0 || mileageTo < 0 || mileageFrom > mileageTo)
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