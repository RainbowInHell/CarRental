using CarRental.BLL.Contracts;
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
        /// Gets a list of all models.
        /// </summary>
        /// <returns>A list of models.</returns>
        [HttpGet]
        public async Task<IActionResult> GetVehicleModels()
        {
            var vehicleModels = await _vehicleModelService.GetVehicleModels();

            return vehicleModels == null ? NotFound("The manufacturers were not found.") : Ok(vehicleModels);
        }
    }
}