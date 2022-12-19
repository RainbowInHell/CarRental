using CarRental.DLL.Entities;

namespace CarRental.DLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IManufacturerRepository ManufacturerRepository { get; }
        IVehicleModelRepository VehicleModelRepository { get; }
        IVehiclesRepository VehicleRepository { get; }
        IBookingRepository BookingRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        Task SaveAsync();
    }
}