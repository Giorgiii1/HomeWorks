using FluentValidation;
using Homework16.Models;

namespace Homework16.Validators;

public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Country is required and cannot be empty.");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required and cannot be empty.");

        RuleFor(x => x.HomeNumber)
            .NotEmpty().WithMessage("Home number is required.");
    }
}