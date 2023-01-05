using CarRental.BLL.Contracts;
using CarRental.BLL.DTO.VehicleModelViews;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleModelsController : ControllerBase
    {
        private readonly IVehicleModelService _vehicleModelService;

        public VehicleModelsController(IVehicleModelService vehicleModelService)
        {
            _vehicleModelService = vehicleModelService;
        }

        /// <summary>
        /// Gets a list of all vehicle models.
        /// </summary>
        /// <returns>A list of all vehicle models.</returns>
        [HttpGet]
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
        public async Task<IActionResult> GetMileageInBetween(int mileageFrom, int mileageTo)
        {
            var vehicleModels = await _vehicleModelService.GetMileageInBetween(mileageFrom, mileageTo);

            return !vehicleModels.Any() ? NotFound("The vehicle models were not found.") : Ok(vehicleModels);
        }

        /// <summary>
        /// Gets a vehicle model by id.
        /// </summary>
        /// <param name="id">The id of the vehicle model to retrieve.</param>
        /// <returns>The vehicle model with the specified id.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleModelById(int id)
        {
            var vehicleModel = await _vehicleModelService.GetVehicleModelById(id);

            return vehicleModel == null ? NotFound("The vehicle model was not found.") : Ok(vehicleModel);
        }

        /// <summary>
        /// Creates a new vehicle model.
        /// </summary>
        /// <param name="vehicleModel">The vehicle model to create.</param>
        /// <returns>A status code indicating the result of the operation.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateVehicleModel(VehicleModelDTO vehicleModel)
        {
            await _vehicleModelService.CreateVehicleModel(vehicleModel);

            return NoContent();
        }

        /// <summary>
        /// Updates an existing vehicle model.
        /// </summary>
        /// <param name="vehicleModel">The updated data for the vehicle model.</param>
        /// <returns>A status code indicating the result of the operation.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateManufacturer(VehicleModelDTO vehicleModel)
        {
            await _vehicleModelService.UpdateVehicleModel(vehicleModel);

            return NoContent();
        }

        /// <summary>
        /// Deletes a vehicle model.
        /// </summary>
        /// <param name="vehicleModel">The vehicle model to delete.</param>
        /// <returns>A status code indicating the result of the operation.</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteManufacturer(VehicleModelWithManufacturerDTO vehicleModel)
        {
            await _vehicleModelService.DeleteVehicleModel(vehicleModel);

            return NoContent();
        }
    }
}