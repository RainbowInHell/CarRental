using CarRental.BLL.Contracts;
using CarRental.BLL.DTO.CustomerViews;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    /// <summary>
    /// Represents a controller for managing customers.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Gets a list of customers.
        /// </summary>
        /// <returns>A list of customers.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerService.GetCustomers();

            return !customers.Any() ? NotFound("The customers were not found.") : Ok(customers);
        }

        /// <summary>
        /// Gets top customers by bookings count.
        /// </summary>
        /// <param name="numOfCustomers">Number of customers to retrieve</param>
        /// <returns>A list of top customers.</returns>
        [HttpGet("bookings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTopCustomersByBookingsCount(int numOfCustomers)
        {
            var customers = await _customerService.GetTopCustomersByBookingsCount(numOfCustomers);

            return !customers.Any() ? NotFound("The customers were not found.") : Ok(customers);
        }

        /// <summary>
        /// Gets a customer by its ID.
        /// </summary>
        /// <param name="id">The ID of the customer to retrieve.</param>
        /// <returns>The customer with the specified id, if it exists; otherwise, a 404 Not Found response.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerById(id);

            return customer == null ? NotFound("The customer was not found.") : Ok(customer);
        }

        /// <summary>
        /// Creates a new customer.
        /// </summary>
        /// <param name="customerDTO">The customer to create.</param>
        /// <returns>A 204 No Content response, indicating that the customer was successfully created.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CreateCustomer(CustomerDTO customerDTO)
        {
            await _customerService.CreateCustomer(customerDTO);

            return NoContent();
        }

        /// <summary>
        /// Updates an existing customer.
        /// </summary>
        /// <param name="customerDTO">The updated data for the customer.</param>
        /// <returns>A 204 No Content response, indicating that the customer was successfully updated.</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateCustomer(CustomerDTO customerDTO)
        {
            await _customerService.UpdateCustomer(customerDTO);

            return NoContent();
        }

        /// <summary>
        /// Deletes an existing customer.
        /// </summary>
        /// <param name="customerDTO">The customer to delete.</param>
        /// <returns>A 204 No Content response, indicating that the customer was successfully deleted.</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteCustomer(CustomerDTO customerDTO)
        {
            await _customerService.DeleteCustomer(customerDTO);

            return NoContent();
        }
    }
}