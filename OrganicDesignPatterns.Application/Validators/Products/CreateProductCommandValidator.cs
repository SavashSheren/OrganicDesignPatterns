using FluentValidation;
using OrganicDesignPatterns.Application.Features.Products.Commands;

namespace OrganicDesignPatterns.Application.Validators.Products;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product name is required.")
            .MinimumLength(2).WithMessage("Product name must be at least 2 characters.")
            .MaximumLength(150).WithMessage("Product name must not exceed 150 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Product price must be greater than zero.");

        RuleFor(x => x.DiscountedPrice)
            .GreaterThanOrEqualTo(0).When(x => x.DiscountedPrice.HasValue)
            .WithMessage("Discounted price cannot be negative.");

        RuleFor(x => x)
            .Must(x => !x.DiscountedPrice.HasValue || x.DiscountedPrice.Value <= x.Price)
            .WithMessage("Discounted price cannot be greater than product price.");

        RuleFor(x => x.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("Stock cannot be negative.");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("Category id must be greater than zero.");
    }
}