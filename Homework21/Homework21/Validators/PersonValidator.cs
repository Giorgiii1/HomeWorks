using FluentValidation;
using Homework21.DTOs;
using Homework21.Models;


namespace Homework.Validators;

public class PersonValidator : AbstractValidator<PersonRequestDto>
{
    public PersonValidator()
    {
        
        RuleFor(x => x.Firstname)
            .NotEmpty().WithMessage("სახელი არ უნდა იყოს ცარიელი.")
            .Length(1, 50).WithMessage("სახელის სიგრძე უნდა იყოს 1-დან 50 სიმბოლომდე.");

        RuleFor(x => x.Lastname)
            .NotEmpty().WithMessage("გვარი არ უნდა იყოს ცარიელი.")
            .Length(1, 50).WithMessage("გვარის სიგრძე უნდა იყოს 1-დან 50 სიმბოლომდე.");

        RuleFor(x => x.JobPosition)
            .NotEmpty().WithMessage("თანამდებობა არ უნდა იყოს ცარიელი.")
            .Length(1, 50).WithMessage("თანამდებობის სიგრძე უნდა იყოს 1-დან 50 სიმბოლომდე.");

        RuleFor(x => x.Salary)
            .InclusiveBetween(0, 10000)
            .WithMessage("ხელფასი უნდა იყოს 0-დან 10,000-მდე ინტერვალში.");

        RuleFor(x => x.WorkExperience)
            .NotNull().WithMessage("სამუშაო გამოცდილება არ უნდა იყოს ცარიელი.")
            .GreaterThanOrEqualTo(0).WithMessage("სამუშაო გამოცდილება არ შეიძლება იყოს უარყოფითი.");

        RuleFor(x => x.PersonAddress)
            .NotNull().WithMessage("მისამართის ობიექტი არ უნდა იყოს ცარიელი.");

        RuleFor(x => x.PersonAddress.Country)
            .NotEmpty().WithMessage("ქვეყნის ველი არ უნდა იყოს ცარიელი.");

        RuleFor(x => x.PersonAddress.City)
            .NotEmpty().WithMessage("ქალაქის ველი არ უნდა იყოს ცარიელი.");

        RuleFor(x => x.PersonAddress.HomeNumber)
            .NotEmpty().WithMessage("სახლის ნომრის ველი არ უნდა იყოს ცარიელი.");
    }
}