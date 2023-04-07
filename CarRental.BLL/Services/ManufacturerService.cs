using CarRental.BLL.Contracts;
using CarRental.DLL.Contracts;
using CarRental.DLL.Entities;
using CarRental.BLL.DTO.ManufacturerViews;
using CarRental.Exceptions.ManufacturerExceptions;

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

        public async Task<IEnumerable<ManufacturerWithModelsDTO>> GetManufacturersWithModels()
        {
            var manufacturers = await _unitOfWork.ManufacturerRepository.GetManufacturersWithModels();

            return manufacturers.Select(m => (ManufacturerWithModelsDTO)m);
        }

        public async Task<ManufacturerDTO> GetManufacturerById(int id)
        {
            var manufacturer = await _unitOfWork.ManufacturerRepository.GetByIdAsync(id);

            return (ManufacturerDTO)manufacturer;
        }

        public async Task CreateManufacturer(ManufacturerDTO manufacturerDTO)
        {
            await _unitOfWork.ManufacturerRepository.CreateAsync((Manufacturer)manufacturerDTO);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateManufacturer(ManufacturerDTO manufacturerDTO)
        {
            var manufacturer = await _unitOfWork.ManufacturerRepository.GetByIdAsync(manufacturerDTO.Id);

            if (manufacturer == null)
            {
                throw new ManufacturerNotFoundException();
            }

            _unitOfWork.ManufacturerRepository.Update((Manufacturer)manufacturerDTO);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteManufacturer(ManufacturerDTO manufacturerDTO)
        {
            var manufacturer = await _unitOfWork.ManufacturerRepository.GetByIdAsync(manufacturerDTO.Id);
            
            if (manufacturer == null)
            {
                throw new ManufacturerNotFoundException();
            }

            _unitOfWork.ManufacturerRepository.Delete((Manufacturer)manufacturerDTO);
            await _unitOfWork.SaveAsync();
        }
    }
}