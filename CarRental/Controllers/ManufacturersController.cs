﻿using CarRental.BLL.Contracts;
using CarRental.BLL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManufacturersController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturersController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        /// <summary>
        /// Gets a list of all manufacturers.
        /// </summary>
        /// <returns>A list of manufacturers.</returns>
        [HttpGet]
        public async Task<IActionResult> GetManufacturers()
        {
            var manufacturers = await _manufacturerService.GetManufacturers();

            return manufacturers == null ? NotFound("The manufacturers were not found.") : Ok(manufacturers);
        }

        /// <summary>
        /// Gets a list of all manufacturers with their associated models.
        /// </summary>
        /// <returns>A list of manufacturers with their associated models.</returns>
        [HttpGet("models")]
        public async Task<IActionResult> GetManufacturersWithModels()
        {
            var manufacturers = await _manufacturerService.GetManufacturersWithModels();

            return manufacturers == null ? NotFound("The manufacturers were not found.") : Ok(manufacturers);
        }

        /// <summary>
        /// Gets a manufacturer by ID.
        /// </summary>
        /// <param name="id">The ID of the manufacturer to retrieve.</param>
        /// <returns>The manufacturer with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetManufacturerById(int id)
        {
            var manufacturer = await _manufacturerService.GetManufacturerById(id);

            return manufacturer == null ? NotFound("The manufacturer was not found.") : Ok(manufacturer);
        }

        /// <summary>
        /// Creates a new manufacturer.
        /// </summary>
        /// <param name="manufacturer">The manufacturer to create.</param>
        /// <returns>A status code indicating the result of the request.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateManufacturer(ManufacturerDTO manufacturer)
        {
            await _manufacturerService.CreateManufacturer(manufacturer);

            return NoContent();
        }

        /// <summary>
        /// Updates an existing manufacturer.
        /// </summary>
        /// <param name="manufacturer">The updated manufacturer information.</param>
        /// <returns>A status code indicating the result of the request.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateManufacturer(ManufacturerDTO manufacturer)
        {
            await _manufacturerService.UpdateManufacturer(manufacturer);

            return NoContent();
        }

        /// <summary>
        /// Deletes a manufacturer.
        /// </summary>
        /// <param name="manufacturer">The manufacturer to delete.</param>
        /// <returns>A status code indicating the result of the request.</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteManufacturer(ManufacturerDTO manufacturer)
        {
            await _manufacturerService.DeleteManufacturer(manufacturer);

            return NoContent();
        }
    }
}