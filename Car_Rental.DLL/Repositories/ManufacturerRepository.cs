using Car_Rental.DLL.Entities;
using CarRental.DLL.Interfaces;
using CarRental.DLL.Repositories;

namespace CarRental.DLL.Repository
{
    public class ManufacturerRepository : GenericRepository<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(CarRentalContext context) : base(context)
        { }

        //TODO IManufacturerRepository methods implementation
    }
}