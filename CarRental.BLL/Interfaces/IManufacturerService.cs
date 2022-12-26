using CarRental.BLL.DTO;

namespace CarRental.BLL.Interfaces
{
    public interface IManufacturerService
    {
        public Task<IEnumerable<ManufacturerDTO>> GetManufacturers();
    }
}