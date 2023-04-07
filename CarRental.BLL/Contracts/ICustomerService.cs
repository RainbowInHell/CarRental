using CarRental.BLL.DTO.CustomerViews;

namespace CarRental.BLL.Contracts
{
    public interface ICustomerService
    {
        public Task<IEnumerable<SimpleCustomerDTO>> GetCustomers();
        public Task<IEnumerable<SimpleCustomerDTO>> GetTopCustomersByBookingsCount(int numOfCustomers);
        public Task<SimpleCustomerDTO> GetCustomerById(int id);
        public Task CreateCustomer(CustomerDTO customerDTO);
        public Task UpdateCustomer(CustomerDTO customerDTO);
        public Task DeleteCustomer(CustomerDTO CustomerDTO);
    }
}