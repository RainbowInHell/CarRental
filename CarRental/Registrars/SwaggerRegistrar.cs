using CarRental.Registrars.Contracts;
using Microsoft.OpenApi.Models;

namespace CarRental.Registrars
{
    public class SwaggerRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "CarRentalAPI", Version = "v1" });
            });
        }
    }
}