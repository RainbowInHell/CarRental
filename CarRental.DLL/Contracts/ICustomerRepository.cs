using CarRental.DLL.Entities;

namespace CarRental.DLL.Contracts
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetTopCustomersByBookingsCount(int numCustomers);
    }
}
