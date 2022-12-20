using CarRental.DLL.Interfaces;
using CarRental.DLL.Repository;

namespace CarRental.DLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarRentalContext _context = null;
        private IManufacturerRepository _manufacturerRepository;
        private IVehicleModelRepository _vehicleModelRepository;
        private IVehiclesRepository _vehiclesRepository;
        private IBookingRepository _bookingRepository;
        private ICustomerRepository _customerRepository;
        private bool _disposed = false;

        public UnitOfWork(CarRentalContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }

            _context = context;
        }

        public IManufacturerRepository ManufacturerRepository
        {
            get { return _manufacturerRepository ?? (_manufacturerRepository = new ManufacturerRepository(_context)); }
        }

        public IVehicleModelRepository VehicleModelRepository
        {
            get { return _vehicleModelRepository ?? (_vehicleModelRepository = new VehicleModelRepository(_context)); }
        }

        public IVehiclesRepository VehicleRepository
        {
            get { return _vehiclesRepository ?? (_vehiclesRepository = new VehicleRepository(_context)); }
        }

        public IBookingRepository BookingRepository
        {
            get { return _bookingRepository ?? (_bookingRepository = new BookingRepository(_context)); }
        }

        public ICustomerRepository CustomerRepository
        {
            get { return _customerRepository ?? (_customerRepository = new CustomerRepository(_context)); }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

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