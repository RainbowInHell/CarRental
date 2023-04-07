namespace CarRental.DLL.Contracts
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