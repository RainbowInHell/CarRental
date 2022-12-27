namespace CarRental.Registrars.Contracts
{
    public interface IWebApplicationBuilderRegistrar : IRegistrar
    {
        void RegisterServices(WebApplicationBuilder builder);
    }
}