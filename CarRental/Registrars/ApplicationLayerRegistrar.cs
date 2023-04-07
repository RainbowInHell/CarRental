using CarRental.BLL.Contracts;
using CarRental.BLL.Services;
using CarRental.DLL.Contracts;
using CarRental.DLL.Repositories;
using CarRental.Registrars.Contracts;
using CarRental.Validators;

namespace CarRental.Registrars
{
    public class ApplicationLayerRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
 
            builder.Services.AddTransient<IManufacturerService, ManufacturerService>();
            builder.Services.AddTransient<ManufacturerDTOValidator>();

            builder.Services.AddTransient<IVehicleModelService, VehicleModelService>();
            builder.Services.AddTransient<IVehicleService, VehicleService>();
            builder.Services.AddTransient<ICustomerService, CustomerService>();
            builder.Services.AddTransient<IBookingService, BookingService>();
        }
    }
}