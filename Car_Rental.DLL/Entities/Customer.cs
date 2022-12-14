namespace Car_Rental.DLL.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string PassportNumber { get; set; }
        public string Adres { get; set; }
        public int DrivingLicenseNumber { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}