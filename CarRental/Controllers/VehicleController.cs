using CarRental.BLL.Contracts;
using CarRental.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicles()
        {
            var vehicles = await _vehicleService.GetVehicles();

            return !vehicles.Any() ? NotFound("The vehicles were not found.") : Ok(vehicles);
        }
    }
}
