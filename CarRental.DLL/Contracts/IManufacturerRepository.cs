using CarRental.DLL.Entities;

namespace CarRental.DLL.Contracts
{
    public interface IManufacturerRepository : IGenericRepository<Manufacturer>
    {
        Task<IEnumerable<Manufacturer>> GetManufacturersWithModels();
    }
}