using Car_Rental.DLL.Entities;
using CarRental.DLL.Interfaces;

namespace CarRental.DLL.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly CarRentalContext context = null;

        public CustomerRepository(CarRentalContext context) : base(context)
        { }

        public IEnumerable<Customer> GetCustomersByName(string customerName)
        {
            return context.Customers.AsEnumerable().Where(x => x.Name == customerName);
        }
    }
}