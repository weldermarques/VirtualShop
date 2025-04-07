using FluentValidation;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Validations;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(c => c.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("Name is required")
            .Length(3, 100)
            .WithMessage("Name length must be between 3 and 100 characters");

        RuleFor(c => c.Description)
            .NotNull()
            .NotEmpty()
            .WithMessage("Description is required")
            .Length(5, 200)
            .WithMessage("Description length must be between 3 and 100 characters");

        RuleFor(c => c.Price)
            .NotNull()
            .WithMessage("Price is required");

        RuleFor(c => c.Stock)
            .NotNull()
            .WithMessage("Stock is required")
            .ExclusiveBetween(1, 9999)
            .WithMessage("Stock must be a value from 1 to 9999");


    }
}
