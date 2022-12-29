using CarRental.BLL.DTO;
using CarRental.BLL.Contracts;
using CarRental.DLL.Contracts;

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

            return manufacturers.Select(manufacturer => (ManufacturerDTO)manufacturer);
        }
    }
}