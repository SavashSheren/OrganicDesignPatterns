using FluentValidation;
using OrganicDesignPatterns.Application.Features.Discounts.Commands;
using OrganicDesignPatterns.Domain.Enums;

namespace OrganicDesignPatterns.Application.Validators.Discounts;

public class CalculateDiscountCommandValidator : AbstractValidator<CalculateDiscountCommand>
{
    public CalculateDiscountCommandValidator()
    {
        RuleFor(x => x.OrderTotal)
            .GreaterThan(0).WithMessage("Order total must be greater than zero.");

        RuleFor(x => x.DiscountValue)
            .GreaterThanOrEqualTo(0).WithMessage("Discount value cannot be negative.");

        RuleFor(x => x.DiscountValue)
            .LessThanOrEqualTo(100)
            .When(x => x.DiscountType == DiscountType.Percentage)
            .WithMessage("Percentage discount cannot be greater than 100.");

        RuleFor(x => x.DiscountType)
            .IsInEnum().WithMessage("Invalid discount type.");
    }
}