using CarRental.BLL.Contracts;
using CarRental.BLL.DTO.VehicleViews;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    /// <summary>
    /// Represents a controller for managing vehicles.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        /// <summary>
        /// Gets a list of vehicles.
        /// </summary>
        /// <returns>A list of vehicles.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetVehicles()
        {
            var vehicles = await _vehicleService.GetVehicles();

            return !vehicles.Any() ? NotFound("The vehicles were not found.") : Ok(vehicles);
        }

        /// <summary>
        /// Gets a list of unrented vehicles.
        /// </summary>
        /// <returns>A list of unrented vehicles.</returns>
        [HttpGet("unrented")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUnRentedVehicles()
        {
            var vehicles = await _vehicleService.GetUnRentedVehicles();

            return !vehicles.Any() ? NotFound("The unrented vehicles were not found.") : Ok(vehicles);
        }

        /// <summary>
        /// Gets a vehicle by its ID.
        /// </summary>
        /// <param name="id">The ID of the vehicle to retrieve.</param>
        /// <returns>The vehicle with the specified id, if it exists; otherwise, a 404 Not Found response.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetManufacturerById(int id)
        {
            var vehicle = await _vehicleService.GetVehicleById(id);

            return vehicle == null ? NotFound("The manufacturer was not found.") : Ok(vehicle);
        }

        /// <summary>
        /// Creates a new vehicle.
        /// </summary>
        /// <param name="vehicleDTO">The vehicle to create.</param>
        /// <returns>A 204 No Content response, indicating that the vehicle was successfully created.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CreateVehicle(VehicleDTO vehicleDTO)
        {
            await _vehicleService.CreateVehicle(vehicleDTO);

            return NoContent();
        }

        /// <summary>
        /// Updates an existing vehicle.
        /// </summary>
        /// <param name="vehicleDTO">The updated data for the vehicle.</param>
        /// <returns>A 204 No Content response, indicating that the vehicle was successfully updated.</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateVehicle(VehicleDTO vehicleDTO)
        {
            await _vehicleService.UpdateVehicle(vehicleDTO);

            return NoContent();
        }

        /// <summary>
        /// Deletes an existing vehicle.
        /// </summary>
        /// <param name="vehicleDTO">The vehicle to delete.</param>
        /// <returns>A 204 No Content response, indicating that the vehicle was successfully deleted.</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteVehicle(VehicleDTO vehicleDTO)
        {
            await _vehicleService.DeleteVehicle(vehicleDTO);

            return NoContent();
        }
    }
}