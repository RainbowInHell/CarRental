using CarRental.BLL.Contracts;
using CarRental.BLL.DTO.VehicleModelViews;
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

        public async Task<IEnumerable<VehicleModelWithManufacturerDTO>> GetVehicleModels()
        {
            var vehicleModels = await _unitOfWork.VehicleModelRepository.GetAllAsync(vm => vm.Manufacturer);

            return vehicleModels.Select(vm => (VehicleModelWithManufacturerDTO)vm);
        }

        public async Task<IEnumerable<VehicleModelWithManufacturerDTO>> GetMileageInBetween(int mileageFrom, int mileageTo)
        {
            var vehicleModels = await _unitOfWork.VehicleModelRepository.GetMileageInBetween(mileageFrom, mileageTo);

            return vehicleModels.Select(vm => (VehicleModelWithManufacturerDTO)vm);
        }

        public async Task<VehicleModelWithManufacturerDTO> GetVehicleModelById(int id)
        {
            var vehicleModel = await _unitOfWork.VehicleModelRepository.GetByIdAsync(id, vm => vm.Manufacturer);

            return (VehicleModelWithManufacturerDTO)vehicleModel;
        }

        public async Task CreateVehicleModel(VehicleModelDTO vehicleModelDTO)
        {
            await _unitOfWork.VehicleModelRepository.CreateAsync((VehicleModel)vehicleModelDTO);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateVehicleModel(VehicleModelDTO vehicleModelDTO)
        {
            _unitOfWork.VehicleModelRepository.Update((VehicleModel)vehicleModelDTO);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteVehicleModel(VehicleModelDTO vehicleModelDTO)
        {
            _unitOfWork.VehicleModelRepository.Delete((VehicleModel)vehicleModelDTO);
            await _unitOfWork.SaveAsync();
        }
    }
}