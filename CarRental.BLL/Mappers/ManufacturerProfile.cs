using AutoMapper;
using Car_Rental.DLL.Entities;
using CarRental.BLL.DTO;

namespace CarRental.BLL.Mappers
{
    public class ManufacturerProfile : Profile
    {
        public ManufacturerProfile()
        {
            CreateMap<Manufacturer, ManufacturerDTO>();
        }
    }
}