using CarRental.BLL.DTO;

namespace CarRental.BLL.Contracts
{
    public interface IManufacturerService
    {
        public Task<IEnumerable<ManufacturerDTO>> GetManufacturers();
    }
}