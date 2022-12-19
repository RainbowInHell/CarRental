using Car_Rental.DLL.Entities;

namespace CarRental.DLL.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        IEnumerable<Customer> GetCustomersByName(string customerName);
    }
}
