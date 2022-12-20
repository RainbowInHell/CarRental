using Car_Rental.DLL.Entities;

namespace CarRental.DLL.Interfaces
{
    public interface IManufacturerRepository : IGenericRepository<Manufacturer>
    {
        Task<IEnumerable<Manufacturer>> GetManufacturersWithModels();
    }
}