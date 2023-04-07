namespace CarRental.Exceptions.ManufacturerExceptions
{
    public class ManufacturerNotFoundException : Exception
    {
        public ManufacturerNotFoundException() : base("Manufacturer not found.")
        { }

        public ManufacturerNotFoundException(string message) : base(message)
        { }

        public ManufacturerNotFoundException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}