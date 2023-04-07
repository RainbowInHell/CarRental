using CarRental.BLL.DTO.ManufacturerViews;
using FluentValidation;

namespace CarRental.Validators
{
    public class ManufacturerDTOValidator : AbstractValidator<ManufacturerDTO>
    {
        public ManufacturerDTOValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Manufacturer name is required.")
                .MaximumLength(25)
                .WithMessage("Manufacturer name cannot be more than 25 characters.");
        }
    }
}