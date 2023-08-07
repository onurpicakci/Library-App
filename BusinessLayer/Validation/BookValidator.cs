using EntityLayer.Entity;
using FluentValidation;

namespace BusinessLayer.Validation;

public class BookValidator : AbstractValidator<Book>
{
    public BookValidator()
    {
        // Kurallar için FluentValidation kütüphanesini kullandım ve kuralları burada belirttim.

        RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(x => x.Name).MinimumLength(3).WithMessage("Name cannot be less than 2 characters");
        RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Author cannot be empty");
        RuleFor(x => x.AuthorName).MinimumLength(3).WithMessage("Author cannot be less than 2 characters");
        RuleFor(x => x.ImageURL).NotEmpty().WithMessage("Image Url cannot be empty");
    }
}