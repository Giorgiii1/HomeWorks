using FluentValidation;
using Homework16.Models;

namespace Homework16.Validators;


public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(x => x.CreateDate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Creation date cannot be in the future.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .Length(1, 50).WithMessage("First name must be between 1 and 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .Length(1, 50).WithMessage("Last name must be between 1 and 50 characters.");

        RuleFor(x => x.JobPosition)
            .NotEmpty().WithMessage("Job position is required.")
            .Length(1, 50).WithMessage("Job position must be between 1 and 50 characters.");

        RuleFor(x => x.Salary)
            .InclusiveBetween(0, 10000).WithMessage("Salary must be between 0 and 10,000.");

        RuleFor(x => x.WorkExperience)
            .NotNull().WithMessage("Work experience is required.")
            .GreaterThanOrEqualTo(0).WithMessage("Work experience cannot be negative.");
        
        RuleFor(x => x.PersonAddress)
            .SetValidator(new AddressValidator());
    }
}