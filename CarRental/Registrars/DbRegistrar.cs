using CarRental.DLL;
using CarRental.Registrars.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Registrars
{
    public class DbRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            var cs = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<CarRentalContext>(options =>
            {
                options.UseNpgsql(cs);
            });
        }
    }
}