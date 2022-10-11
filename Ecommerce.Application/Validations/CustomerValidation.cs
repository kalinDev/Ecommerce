using ECommerce.Domain.Models;
using FluentValidation;

namespace ECommerce.Application.Validations
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("The field {PropertyName} must be provided")
                .Length(2, 200).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("The field {PropertyName} must be provided")
                .EmailAddress().WithMessage("The field {PropertyName} must be a valid email address")
                .Length(2, 100).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters");
            
            RuleFor(c => c.BirthDate)
                .NotEmpty().WithMessage("The field {PropertyName} must be provided");

            RuleForEach(x => x.Addresses).SetValidator(new AddressValidation());
        }
    }
}
