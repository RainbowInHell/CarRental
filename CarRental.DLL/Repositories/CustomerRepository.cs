using CarRental.DLL.Entities;
using CarRental.DLL.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DLL.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CarRentalContext context) : base(context)
        { }

        public async Task<IEnumerable<Customer>> GetTopCustomersByBookingsCount(int numOfCustomers)
        {
            return await _context.Customers
                .AsNoTracking()
                .OrderByDescending(x => x.Bookings.Count())
                .Take(numOfCustomers)
                .ToListAsync();
        }
    }
}