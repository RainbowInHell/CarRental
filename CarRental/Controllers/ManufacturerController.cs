using CarRental.BLL.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturersController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllManufacturers()
        {
            return Ok(await _manufacturerService.GetManufacturers());
        }
    }
}