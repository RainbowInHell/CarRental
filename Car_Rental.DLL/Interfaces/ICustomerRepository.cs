using Car_Rental.DLL.Entities;

namespace CarRental.DLL.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetTopCustomersByBookingsCount(int numCustomers);
    }
}
