using CarRental.DLL.Entities;

namespace CarRental.BLL.DTO.CustomerViews
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string PassportNumber { get; set; }
        public string Adres { get; set; }
        public string DrivingLicenseNumber { get; set; }

        public static explicit operator Customer(CustomerDTO customerDTO)
        {
            return customerDTO == null ? null : new Customer
            {
                Id = customerDTO.Id,
                Name = customerDTO.Name,
                Surname = customerDTO.Surname,
                Email = customerDTO.Email,
                ContactNumber = customerDTO.ContactNumber,
                PassportNumber = customerDTO.PassportNumber,
                Adres = customerDTO.Adres,
                DrivingLicenseNumber = customerDTO.DrivingLicenseNumber
            };
        }
    }
}