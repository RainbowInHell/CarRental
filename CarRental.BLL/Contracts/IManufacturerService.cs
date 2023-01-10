using CarRental.BLL.DTO.ManufacturerViews;

namespace CarRental.BLL.Contracts
{
    public interface IManufacturerService
    {
        public Task<IEnumerable<ManufacturerDTO>> GetManufacturers();
        public Task<IEnumerable<ManufacturerWithModelsDTO>> GetManufacturersWithModels();
        public Task<ManufacturerDTO> GetManufacturerById(int id);
        public Task CreateManufacturer(ManufacturerDTO manufacturerDTO);
        public Task UpdateManufacturer(ManufacturerDTO manufacturerDTO);
        public Task DeleteManufacturer(ManufacturerDTO manufacturerDTO);
    }
}