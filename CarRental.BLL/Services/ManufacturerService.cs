using CarRental.BLL.DTO;
using CarRental.BLL.Contracts;
using CarRental.DLL.Contracts;
using CarRental.DLL.Entities;

namespace CarRental.BLL.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManufacturerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ManufacturerDTO>> GetManufacturers()
        {
            var manufacturers = await _unitOfWork.ManufacturerRepository.GetAllAsync();

            return manufacturers.Select(m => (ManufacturerDTO)m);
        }

        public async Task<IEnumerable<ManufacturerDTO>> GetManufacturersWithModels()
        {
            var manufacturers = await _unitOfWork.ManufacturerRepository.GetManufacturersWithModels();

            return manufacturers.Select(m => (ManufacturerDTO)m);
        }

        public async Task<ManufacturerDTO> GetManufacturerById(int id)
        {
            var manufacturer = await _unitOfWork.ManufacturerRepository.GetByIdAsync(id);

            return (ManufacturerDTO)manufacturer;
        }

        public async Task CreateManufacturer(ManufacturerDTO manufacturer)
        {
            await _unitOfWork.ManufacturerRepository.CreateAsync((Manufacturer)manufacturer);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateManufacturer(ManufacturerDTO manufacturer)
        {
            _unitOfWork.ManufacturerRepository.Update((Manufacturer)manufacturer);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteManufacturer(ManufacturerDTO manufacturer)
        {
            _unitOfWork.ManufacturerRepository.Delete((Manufacturer)manufacturer);
            await _unitOfWork.SaveAsync();
        }
    }
}