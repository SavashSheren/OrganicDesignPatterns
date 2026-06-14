using FluentValidation;
using OrganicDesignPatterns.Application.Features.Shipping.Commands;

namespace OrganicDesignPatterns.Application.Validators.Shipping;

public class CalculateShippingCommandValidator : AbstractValidator<CalculateShippingCommand>
{
    public CalculateShippingCommandValidator()
    {
        RuleFor(x => x.BaseShippingPrice)
            .GreaterThan(0)
            .WithMessage("Base shipping price must be greater than zero.");
    }
}