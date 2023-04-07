using CarRental.BLL.Contracts;
using CarRental.BLL.DTO.ManufacturerViews;
using CarRental.Exceptions.ManufacturerExceptions;
using CarRental.Validators;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    /// <summary>
    /// Represents a controller for managing manufacturers.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;
        private readonly ManufacturerDTOValidator _validator;

        public ManufacturerController(IManufacturerService manufacturerService, ManufacturerDTOValidator validator)
        {
            _manufacturerService = manufacturerService;
            _validator = validator;
        }

        /// <summary>
        /// Gets a list of manufacturers.
        /// </summary>
        /// <returns>A list of manufacturers.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetManufacturers()
        {
            var manufacturers = await _manufacturerService.GetManufacturers();

            return !manufacturers.Any() ? NotFound("The manufacturers were not found.") : Ok(manufacturers);
        }

        /// <summary>
        /// Gets a list of manufacturers with their associated vehicle models.
        /// </summary>
        /// <returns>A list of manufacturers with their associated vehicle models.</returns>
        [HttpGet("models")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetManufacturersWithModels()
        {
            var manufacturers = await _manufacturerService.GetManufacturersWithModels();

            return !manufacturers.Any() ? NotFound("The manufacturers were not found.") : Ok(manufacturers);
        }

        /// <summary>
        /// Gets a manufacturer by its ID.
        /// </summary>
        /// <param name="id">The ID of the manufacturer to retrieve.</param>
        /// <returns>The manufacturer with the specified id, if it exists; otherwise, a 404 Not Found response.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetManufacturerById(int id)
        {
            var manufacturer = await _manufacturerService.GetManufacturerById(id);

            return manufacturer == null ? NotFound("The manufacturer was not found.") : Ok(manufacturer);
        }

        /// <summary>
        /// Creates a new manufacturer.
        /// </summary>
        /// <param name="manufacturerDTO">The manufacturer to create.</param>
        /// <returns>A 204 No Content response, indicating that the manufacturer was successfully created.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CreateManufacturer(ManufacturerDTO manufacturerDTO)
        {
            var validationResult = _validator.Validate(manufacturerDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            await _manufacturerService.CreateManufacturer(manufacturerDTO);

            return NoContent();
        }

        /// <summary>
        /// Updates an existing manufacturer.
        /// </summary>
        /// <param name="manufacturerDTO">The updated data for the manufacturer.</param>
        /// <returns>A 204 No Content response, indicating that the manufacturer was successfully updated.</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateManufacturer(ManufacturerDTO manufacturerDTO)
        {
            try
            {
                var validationResult = _validator.Validate(manufacturerDTO);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                await _manufacturerService.UpdateManufacturer(manufacturerDTO);
                
                return NoContent();
            }
            catch (ManufacturerNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Deletes an existing manufacturer.
        /// </summary>
        /// <param name="manufacturerDTO">The manufacturer to delete.</param>
        /// <returns>A 204 No Content response, indicating that the manufacturer was successfully deleted.</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteManufacturer(ManufacturerDTO manufacturerDTO)
        {
            try
            {
                var validationResult = _validator.Validate(manufacturerDTO);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                await _manufacturerService.DeleteManufacturer(manufacturerDTO);
                return NoContent();
            }
            catch (ManufacturerNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}