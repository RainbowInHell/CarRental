using CarRental.BLL.Contracts;
using CarRental.BLL.DTO.VehicleModelViews;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    /// <summary>
    /// Represents a controller for managing vehicle models.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleModelController : ControllerBase
    {
        private readonly IVehicleModelService _vehicleModelService;

        public VehicleModelController(IVehicleModelService vehicleModelService)
        {
            _vehicleModelService = vehicleModelService;
        }

        /// <summary>
        /// Gets a list of vehicle models.
        /// </summary>
        /// <returns>A list of vehicle models.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetVehicleModels()
        {
            var vehicleModels = await _vehicleModelService.GetVehicleModels();

            return !vehicleModels.Any() ? NotFound("The vehicle models were not found.") : Ok(vehicleModels);
        }

        /// <summary>
        /// Gets a list of vehicle models with mileage between the given values.
        /// </summary>
        /// <param name="mileageFrom">The minimum mileage to filter by.</param>
        /// <param name="mileageTo">The maximum mileage to filter by.</param>
        /// <returns>A list of vehicle models with mileage between the given values.</returns>
        [HttpGet("mileage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMileageInBetween(int mileageFrom, int mileageTo)
        {
            var vehicleModels = await _vehicleModelService.GetMileageInBetween(mileageFrom, mileageTo);

            return !vehicleModels.Any() ? NotFound("The vehicle models were not found.") : Ok(vehicleModels);
        }

        /// <summary>
        /// Gets a vehicle model by its ID.
        /// </summary>
        /// <param name="id">The ID of the vehicle model to retrieve.</param>
        /// <returns>The vehicle model with the specified id, if it exists; otherwise, a 404 Not Found response.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetVehicleModelById(int id)
        {
            var vehicleModel = await _vehicleModelService.GetVehicleModelById(id);

            return vehicleModel == null ? NotFound("The vehicle model was not found.") : Ok(vehicleModel);
        }

        /// <summary>
        /// Creates a new vehicle model.
        /// </summary>
        /// <param name="vehicleModel">The vehicle model to create.</param>
        /// <returns>A 204 No Content response, indicating that the vehicle model was successfully created.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CreateVehicleModel(VehicleModelDTO vehicleModelDTO)
        {
            await _vehicleModelService.CreateVehicleModel(vehicleModelDTO);

            return NoContent();
        }


        /// <summary>
        /// Updates an existing vehicle model.
        /// </summary>
        /// <param name="vehicleModel">The updated data for the vehicle model.</param>
        /// <returns>A 204 No Content response, indicating that the vehicle model was successfully updated.</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateVehicleModel(VehicleModelDTO vehicleModelDTO)
        {
            await _vehicleModelService.UpdateVehicleModel(vehicleModelDTO);

            return NoContent();
        }

        /// <summary>
        /// Deletes an existing vehicle model.
        /// </summary>
        /// <param name="vehicleModel">The vehicle model to delete.</param>
        /// <returns>A 204 No Content response, indicating that the vehicle model was successfully deleted.</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteVehicleModel(VehicleModelDTO vehicleModelDTO)
        {
            await _vehicleModelService.DeleteVehicleModel(vehicleModelDTO);

            return NoContent();
        }
    }
}