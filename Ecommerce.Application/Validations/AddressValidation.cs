using ECommerce.Domain.Models;
using FluentValidation;

namespace ECommerce.Application.Validations
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation() 
        {
            RuleFor(a => a.Street)
                .NotEmpty().WithMessage("The field {PropertyName} must be provided")
                .Length(2, 200).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters");

            RuleFor(a => a.HouseNumber)
                .NotEmpty().WithMessage("The field {PropertyName} must be provided")
                .Length(1, 50).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters");

            RuleFor(a => a.PhoneNumber)
                .NotEmpty().WithMessage("The field {PropertyName} must be provided")
                .Length(7, 25).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters");

            RuleFor(a => a.City)
                .NotEmpty().WithMessage("The field {PropertyName} must be provided")
                .Length(2, 100).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters");

            RuleFor(a => a.State)
                .NotEmpty().WithMessage("The field {PropertyName} must be provided")
                .Length(2, 50).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters");

            RuleFor(a => a.Complement)
                .NotEmpty().NotEmpty().WithMessage("The field {PropertyName} must be provided")
                .Length(2, 300).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters");

            RuleFor(a => a.District)
                .NotEmpty().WithMessage("The field {PropertyName} must be provided")
                .Length(2, 100).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters");

            RuleFor(a => a.ZipCode)
                .NotEmpty().WithMessage("The field {PropertyName} must be provided")
                .Length(8).WithMessage("The field {PropertyName} must be {MaxLength} characters")
                .Matches(@"^\d{5}-\d{3}$").WithMessage("The field {PropertyName} must be a valid zip code");
        }
    }
}
