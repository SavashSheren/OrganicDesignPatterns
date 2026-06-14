using FluentValidation;
using OrganicDesignPatterns.Application.Features.OrderValidation.Commands;

namespace OrganicDesignPatterns.Application.Validators.OrderValidation;

public class ValidateOrderCommandValidator : AbstractValidator<ValidateOrderCommand>
{
    public ValidateOrderCommandValidator()
    {
        RuleFor(x => x.CustomerName)
            .MaximumLength(100)
            .WithMessage("Customer name must not exceed 100 characters.");

        RuleFor(x => x.CustomerEmail)
            .MaximumLength(100)
            .WithMessage("Customer email must not exceed 100 characters.");

        RuleFor(x => x.ShippingAddress)
            .MaximumLength(250)
            .WithMessage("Shipping address must not exceed 250 characters.");

        RuleForEach(x => x.Items)
            .ChildRules(item =>
            {
                item.RuleFor(x => x.ProductId)
                    .GreaterThan(0)
                    .WithMessage("Product id must be greater than zero.");

                item.RuleFor(x => x.ProductName)
                    .NotEmpty()
                    .WithMessage("Product name is required.");

                item.RuleFor(x => x.RequestedQuantity)
                    .GreaterThan(0)
                    .WithMessage("Requested quantity must be greater than zero.");

                item.RuleFor(x => x.AvailableStock)
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("Available stock cannot be negative.");
            });
    }
}