using Car_Rental.DLL.Entities;
using CarRental.DLL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DLL.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CarRentalContext context) : base(context)
        { }

        public IEnumerable<Customer> GetTopCustomersByBookingsCount(int numCustomers)
        {
            if(numCustomers <= 0) 
            {
                throw new ArgumentOutOfRangeException();
            }

            return context.Customers
                          .AsNoTracking()
                          .AsEnumerable()
                          .OrderByDescending(c => c.Bookings.Count())
                          .Take(numCustomers)
                          .ToList();
        }
    }
}