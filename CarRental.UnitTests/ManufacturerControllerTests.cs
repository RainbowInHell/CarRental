using CarRental.BLL.Contracts;
using CarRental.BLL.DTO.ManufacturerViews;
using CarRental.Controllers;
using CarRental.Exceptions.ManufacturerExceptions;
using CarRental.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CarRentalTests
{
    public class ManufacturerControllerTests
    {
        private readonly ManufacturerController _controller;
        private readonly ManufacturerDTOValidator _validator;
        private readonly Mock<IManufacturerService> _mockManufacturerService;

        public ManufacturerControllerTests()
        {
            _mockManufacturerService = new Mock<IManufacturerService>();
            _validator = new ManufacturerDTOValidator();
            _controller = new ManufacturerController(_mockManufacturerService.Object, _validator);
        }

        [Fact]
        public async Task GetManufacturers_ReturnsOkResult()
        {
            // Arrange
            var manufacturers = new List<ManufacturerDTO>
            {
                new ManufacturerDTO { Id = 1, Name = "Manufacturer 1" },
                new ManufacturerDTO { Id = 2, Name = "Manufacturer 2" }
            };
            _mockManufacturerService.Setup(x => x.GetManufacturers()).ReturnsAsync(manufacturers);

            // Act
            var result = await _controller.GetManufacturers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedManufacturers = Assert.IsAssignableFrom<IEnumerable<ManufacturerDTO>>(okResult.Value);
            Assert.Equal(2, returnedManufacturers.Count());
            Assert.Equal("Manufacturer 1", returnedManufacturers.First().Name);
        }

        [Fact]
        public async Task GetManufacturers_ReturnsNotFound_WhenNoManufacturers()
        {
            // Arrange
            var manufacturers = Enumerable.Empty<ManufacturerDTO>();
            _mockManufacturerService.Setup(x => x.GetManufacturers()).ReturnsAsync(manufacturers);

            // Act
            var result = await _controller.GetManufacturers();

            // Assert
            var notFound = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("The manufacturers were not found.", notFound.Value);
        }

        [Fact]
        public async Task GetManufacturerById_ReturnsOkResult()
        {
            // Arrange
            var manufacturer = new ManufacturerDTO { Id = 1, Name = "Manufacturer 1" };
            _mockManufacturerService.Setup(x => x.GetManufacturerById(1)).ReturnsAsync(manufacturer);

            // Act
            var result = await _controller.GetManufacturerById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedManufacturer = Assert.IsType<ManufacturerDTO>(okResult.Value);
            Assert.Equal(1, returnedManufacturer.Id);
            Assert.Equal("Manufacturer 1", returnedManufacturer.Name);
        }

        [Fact]
        public async Task GetManufacturerById_ReturnsNotFound_WhenManufacturerNotFound()
        {
            // Arrange
            _mockManufacturerService.Setup(x => x.GetManufacturerById(1)).ReturnsAsync((ManufacturerDTO)null);

            // Act
            var result = await _controller.GetManufacturerById(1);

            // Assert
            var notFound = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("The manufacturer was not found.", notFound.Value);
        }

        [Fact]
        public async Task CreateManufacturer_ReturnsNoContentResult()
        {
            // Arrange
            var manufacturerDTO = new ManufacturerDTO { Id = 1, Name = "Manufacturer 1" };

            // Act
            var result = await _controller.CreateManufacturer(manufacturerDTO);

            // Assert
            var noContentResult = Assert.IsType<NoContentResult>(result);
            _mockManufacturerService.Verify(x => x.CreateManufacturer(manufacturerDTO), Times.Once);
        }

        [Fact]
        public async Task CreateManufacturer_ReturnsBadRequest_WhenInvalidData()
        {
            // Arrange
            var manufacturerDTO = new ManufacturerDTO();
            var validationResult = new ValidationResult(new[] { new ValidationFailure("Name", "Manufacturer name is required.") });

            // Act
            var result = await _controller.CreateManufacturer(manufacturerDTO);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            var expectedErrorMessage = validationResult.Errors.First().ErrorMessage;
            var actualErrorMessage = ((List<ValidationFailure>)badRequest.Value).First().ErrorMessage;
            Assert.Equal(expectedErrorMessage, actualErrorMessage);
        }

        [Fact]
        public async Task UpdateManufacturer_ReturnsNoContentResult()
        {
            // Arrange
            var manufacturerDTO = new ManufacturerDTO { Id = 1, Name = "Manufacturer 1" };

            // Act
            var result = await _controller.UpdateManufacturer(manufacturerDTO);

            // Assert
            var noContentResult = Assert.IsType<NoContentResult>(result);
            _mockManufacturerService.Verify(x => x.UpdateManufacturer(manufacturerDTO), Times.Once);
        }

        [Fact]
        public async Task UpdateManufacturer_ReturnsNotFound_WhenManufacturerNotFound()
        {
            // Arrange
            var manufacturerDTO = new ManufacturerDTO { Id = 1, Name = "Manufacturer 1" };
            _mockManufacturerService.Setup(x => x.UpdateManufacturer(manufacturerDTO)).ThrowsAsync(new ManufacturerNotFoundException());

            // Act
            var result = await _controller.UpdateManufacturer(manufacturerDTO);

            // Assert
            var notFound = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Manufacturer not found.", notFound.Value);
        }

        [Fact]
        public async Task UpdateManufacturer_ReturnsBadRequest_WhenInvalidData()
        {
            // Arrange
            var manufacturerDTO = new ManufacturerDTO { Id = 1 };
            var validationResult = new ValidationResult(new[] { new ValidationFailure("Name", "Manufacturer name is required.") });

            // Act
            var result = await _controller.UpdateManufacturer(manufacturerDTO);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            var expectedErrorMessage = validationResult.Errors.First().ErrorMessage;
            var actualErrorMessage = ((List<ValidationFailure>)badRequest.Value).First().ErrorMessage;
            Assert.Equal(expectedErrorMessage, actualErrorMessage);
        }

        [Fact]
        public async Task DeleteManufacturer_ReturnsNoContentResult()
        {
            // Arrange
            var manufacturerDTO = new ManufacturerDTO { Id = 1, Name = "Manufacturer 1" };

            // Act
            var result = await _controller.DeleteManufacturer(manufacturerDTO);

            // Assert
            var noContentResult = Assert.IsType<NoContentResult>(result);
            _mockManufacturerService.Verify(x => x.DeleteManufacturer(manufacturerDTO), Times.Once);
        }

        [Fact]
        public async Task DeleteManufacturer_ReturnsNotFound_WhenManufacturerNotFound()
        {
            // Arrange
            var manufacturerDTO = new ManufacturerDTO { Id = 1, Name = "Manufacturer 1" };
            _mockManufacturerService.Setup(x => x.DeleteManufacturer(manufacturerDTO)).ThrowsAsync(new ManufacturerNotFoundException());

            // Act
            var result = await _controller.DeleteManufacturer(manufacturerDTO);

            // Assert
            var notFound = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Manufacturer not found.", notFound.Value);
        }
    }
}