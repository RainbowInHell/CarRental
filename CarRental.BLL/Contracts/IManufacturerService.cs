using CarRental.BLL.DTO.ManufacturerProfiles;

namespace CarRental.BLL.Contracts
{
    public interface IManufacturerService
    {
        public Task<IEnumerable<ManufacturerDTO>> GetManufacturers();
        public Task<IEnumerable<ManufacturerWithModelsDTO>> GetManufacturersWithModels();
        public Task<ManufacturerDTO> GetManufacturerById(int id);
        public Task CreateManufacturer(ManufacturerDTO manufacturer);
        public Task UpdateManufacturer(ManufacturerDTO manufacturer);
        public Task DeleteManufacturer(ManufacturerDTO manufacturer);
    }
}