using Car_Rental.DLL.Entities;
using CarRental.DLL.Interfaces;
using CarRental.DLL.Repositories;

namespace CarRental.DLL.Repository
{
    public class ManufacturerRepository : GenericRepository<Manufacturer>, IManufacturerRepository
    {
        private readonly CarRentalContext context = null;

        public ManufacturerRepository(CarRentalContext context) : base(context)
        { }

        public Manufacturer GetManufacturerByName(string manufacturerName)
        {
            return context.Set<Manufacturer>().FirstOrDefault(x => x.Name == manufacturerName);
        }
    }
}