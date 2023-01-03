using CarRental.DLL.Contracts;

namespace CarRental.DLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarRentalContext _context;
        private IManufacturerRepository? _manufacturerRepository;
        private IVehicleModelRepository? _vehicleModelRepository;
        private IVehiclesRepository? _vehiclesRepository;
        private IBookingRepository? _bookingRepository;
        private ICustomerRepository? _customerRepository;
        private bool _disposed = false;

        public UnitOfWork(CarRentalContext context)
        {
            _context = context;
        }

        public IManufacturerRepository ManufacturerRepository =>
            _manufacturerRepository ??= new ManufacturerRepository(_context);

        public IVehicleModelRepository VehicleModelRepository =>
            _vehicleModelRepository ??= new VehicleModelRepository(_context);

        public IVehiclesRepository VehicleRepository =>
            _vehiclesRepository ??= new VehicleRepository(_context);

        public IBookingRepository BookingRepository =>
            _bookingRepository ??= new BookingRepository(_context);

        public ICustomerRepository CustomerRepository =>
            _customerRepository ??= new CustomerRepository(_context);

        public async Task SaveAsync() => await _context.SaveChangesAsync();

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}