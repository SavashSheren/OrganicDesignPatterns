using FluentValidation;
using OrganicDesignPatterns.Application.Features.OrderEvents.Commands;

namespace OrganicDesignPatterns.Application.Validators.OrderEvents;

public class ApproveOrderCommandValidator : AbstractValidator<ApproveOrderCommand>
{
    public ApproveOrderCommandValidator()
    {
        RuleFor(x => x.OrderNumber)
            .NotEmpty()
            .WithMessage("Order number is required.")
            .MaximumLength(50)
            .WithMessage("Order number must not exceed 50 characters.");

        RuleFor(x => x.CustomerName)
            .NotEmpty()
            .WithMessage("Customer name is required.")
            .MaximumLength(100)
            .WithMessage("Customer name must not exceed 100 characters.");

        RuleFor(x => x.CustomerEmail)
            .NotEmpty()
            .WithMessage("Customer email is required.")
            .EmailAddress()
            .WithMessage("Customer email is not valid.");

        RuleFor(x => x.ProductId)
            .GreaterThan(0)
            .WithMessage("Product id must be greater than zero.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than zero.");

        RuleFor(x => x.TotalAmount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Total amount cannot be negative.");
    }
}