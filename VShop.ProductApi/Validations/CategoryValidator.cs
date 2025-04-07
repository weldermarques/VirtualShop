using FluentValidation;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Validations;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(c => c.Name)
            .NotNull().NotEmpty()
                .WithMessage("Name is required")
            .Length(3, 100)
                .WithMessage("Name length must be between 3 and 100 characters");
    }
}
