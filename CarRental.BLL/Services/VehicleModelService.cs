using CarRental.BLL.Contracts;
using CarRental.BLL.DTO;
using CarRental.DLL.Contracts;

namespace CarRental.BLL.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehicleModelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<VehicleModelDTO>> GetVehicleModels()
        {
            var vehicleModels = await _unitOfWork.VehicleModelRepository.GetAllAsync();

            return vehicleModels.Select(vm => (VehicleModelDTO)vm);
        }
    }
}