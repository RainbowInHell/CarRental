using CarRental.DLL.Entities;

namespace CarRental.BLL.DTO.CustomerViews
{
    public class SimpleCustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ContactNumber { get; set; }
        public string PassportNumber { get; set; }

        public static explicit operator SimpleCustomerDTO(Customer customer)
        {
            return customer == null ? null : new SimpleCustomerDTO
            {
                Id = customer.Id,
                Name = customer.Name,
                Surname = customer.Surname,
                ContactNumber = customer.ContactNumber,
                PassportNumber = customer.PassportNumber
            };
        }
    }
}