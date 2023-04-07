using CarRental.BLL.Contracts;
using CarRental.BLL.DTO.CustomerViews;
using CarRental.DLL.Contracts;
using CarRental.DLL.Entities;

namespace CarRental.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SimpleCustomerDTO>> GetCustomers()
        {
            var customers = await _unitOfWork.CustomerRepository.GetAllAsync();

            return customers.Select(c => (SimpleCustomerDTO)c);
        }

        public async Task<IEnumerable<SimpleCustomerDTO>> GetTopCustomersByBookingsCount(int numOfCustomers)
        {
            var customers = await _unitOfWork.CustomerRepository.GetTopCustomersByBookingsCount(numOfCustomers);

            return customers.Select(c => (SimpleCustomerDTO)c);
        }

        public async Task<SimpleCustomerDTO> GetCustomerById(int id)
        {
            var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(id);

            return (SimpleCustomerDTO)customer;
        }

        public async Task CreateCustomer(CustomerDTO customerDTO)
        {
            await _unitOfWork.CustomerRepository.CreateAsync((Customer)customerDTO);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateCustomer(CustomerDTO customerDTO)
        {
            _unitOfWork.CustomerRepository.Update((Customer)customerDTO);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteCustomer(CustomerDTO customerDTO)
        {
            _unitOfWork.CustomerRepository.Delete((Customer)customerDTO);
            await _unitOfWork.SaveAsync();
        }
    }
}