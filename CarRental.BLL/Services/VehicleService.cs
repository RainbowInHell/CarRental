using CarRental.BLL.Contracts;
using CarRental.BLL.DTO.VehicleViews;
using CarRental.DLL.Contracts;
using CarRental.DLL.Entities;

namespace CarRental.BLL.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehicleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<VehicleWithModelDTO>> GetVehicles()
        {
            var vehicles = await _unitOfWork.VehicleRepository.GetAllAsync(v => v.VehicleModel.Manufacturer);

            return vehicles.Select(v => (VehicleWithModelDTO)v);
        }

        public async Task<IEnumerable<VehicleWithModelDTO>> GetUnRentedVehicles()
        {
            var vehicles = await _unitOfWork.VehicleRepository.GetUnRentedVehicles();

            return vehicles.Select(v => (VehicleWithModelDTO)v);
        }

        public async Task<VehicleWithModelDTO> GetVehicleById(int id)
        {
            var vehicle = await _unitOfWork.VehicleRepository.GetByIdAsync(id, v => v.VehicleModel.Manufacturer);

            return (VehicleWithModelDTO)vehicle;
        }

        public async Task CreateVehicle(VehicleDTO vehicleDTO)
        {
            await _unitOfWork.VehicleRepository.CreateAsync((Vehicle)vehicleDTO);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateVehicle(VehicleDTO vehicleDTO)
        {
            _unitOfWork.VehicleRepository.Update((Vehicle)vehicleDTO);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteVehicle(VehicleDTO vehicleDTO)
        {
            _unitOfWork.VehicleRepository.Delete((Vehicle)vehicleDTO);
            await _unitOfWork.SaveAsync();
        }
    }
}