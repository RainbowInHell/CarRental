namespace CarRental.Registrars.Contracts
{
    public interface IWebApplicationRegistrar : IRegistrar
    {
        public void RegisterPipelineComponents(WebApplication app);
    }
}