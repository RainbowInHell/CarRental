using CarRental.BLL.Interfaces;
using CarRental.BLL.Mappers;
using CarRental.BLL.Services;
using CarRental.DLL;
using CarRental.DLL.Interfaces;
using CarRental.DLL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace CarRental
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "CarRentalAPI", Version = "v1" });
            });

            services.AddDbContext<CarRentalContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IManufacturerService, ManufacturerService>();
            services.AddAutoMapper(typeof(ManufacturerProfile));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(x =>
                {
                    x.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    x.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(x =>
            {
                x.MapControllers();
            });
        }
    }
}