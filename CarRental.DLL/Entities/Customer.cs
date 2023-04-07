namespace CarRental.DLL.Entities
{
    public class Customer : BaseEntity
    {
        public override int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string PassportNumber { get; set; }
        public string Adres { get; set; }
        public string DrivingLicenseNumber { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}