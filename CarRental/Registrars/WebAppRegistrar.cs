using CarRental.Registrars.Contracts;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace CarRental.Registrars
{
    public class WebAppRegistrar : IWebApplicationRegistrar
    {
        public void RegisterPipelineComponents(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                x.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(x =>
            {
                x.MapControllers();
            });
        }
    }
}