using FluentValidation;
using Practice20.Models;

namespace Practice20.Validators;

public class BookValidator : AbstractValidator<Book>
{
    public BookValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("სათაური აუცილებელია")
            .MinimumLength(2).WithMessage("სათაური უნდა იყოს მინიმუმ 2 სიმბოლო");

        RuleFor(x => x.Author)
            .NotEmpty().WithMessage("ავტორი აუცილებელია")
            .MinimumLength(3).WithMessage("ავტორის სახელი უნდა იყოს მინიმუმ 3 სიმბოლო");

        RuleFor(x => x.PublishYear)
            .InclusiveBetween(1900, 2026)
            .WithMessage("გამოცემის წელი უნდა იყოს 1900-დან 2026-მდე");
    }
}