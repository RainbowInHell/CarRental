using Car_Rental.DLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DLL.Interfaces
{
    //Just a template for a review
    public interface IManufacturerRepository : IGenericRepository<Manufacturer>
    {
        //TODO: Specific methods for Manufacturer entity.
        //An example
        //IEnumerable<Manufacturer> GetManufacturerByName(string manufacturerName);
    }
}
