using CarRental.BLL.Contracts;
using CarRental.BLL.DTO;
using CarRental.DLL.Contracts;
using CarRental.DLL.Entities;

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

        public async Task<IEnumerable<VehicleModelDTO>> GetMileageInBetween(int mileageFrom, int mileageTo)
        {
            var vehicleModels = await _unitOfWork.VehicleModelRepository.GetMileageInBetween(mileageFrom, mileageTo);

            return vehicleModels.Select(vm => (VehicleModelDTO)vm);
        }

        public async Task<VehicleModelDTO> GetVehicleModelById(int id)
        {
            var vehicleModel = await _unitOfWork.VehicleModelRepository.GetByIdAsync(id);

            return (VehicleModelDTO)vehicleModel;
        }

        public async Task CreateVehicleModel(VehicleModelDTO vehicleModel)
        {
            await _unitOfWork.VehicleModelRepository.CreateAsync((VehicleModel)vehicleModel);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateVehicleModel(VehicleModelDTO vehicleModel)
        {
            _unitOfWork.VehicleModelRepository.Update((VehicleModel)vehicleModel);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteVehicleModel(VehicleModelDTO vehicleModel)
        {
            _unitOfWork.VehicleModelRepository.Delete((VehicleModel)vehicleModel);
            await _unitOfWork.SaveAsync();
        }
    }
}