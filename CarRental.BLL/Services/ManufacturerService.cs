using AutoMapper;
using CarRental.BLL.DTO;
using CarRental.BLL.Contracts;
using CarRental.DLL.Contracts;

namespace CarRental.BLL.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ManufacturerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ManufacturerDTO>> GetManufacturers()
        {
            var manufacturers = await _unitOfWork.ManufacturerRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ManufacturerDTO>>(manufacturers);
        }
    }
}