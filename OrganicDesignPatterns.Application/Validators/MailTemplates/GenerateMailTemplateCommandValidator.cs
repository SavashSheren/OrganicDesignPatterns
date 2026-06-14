using FluentValidation;
using OrganicDesignPatterns.Application.Features.MailTemplates.Commands;

namespace OrganicDesignPatterns.Application.Validators.MailTemplates;

public class GenerateMailTemplateCommandValidator : AbstractValidator<GenerateMailTemplateCommand>
{
    public GenerateMailTemplateCommandValidator()
    {
        RuleFor(x => x.OrderStatus)
            .IsInEnum()
            .WithMessage("Invalid order status.");

        RuleFor(x => x.CustomerName)
            .NotEmpty()
            .WithMessage("Customer name is required.")
            .MaximumLength(100)
            .WithMessage("Customer name must not exceed 100 characters.");

        RuleFor(x => x.OrderNumber)
            .NotEmpty()
            .WithMessage("Order number is required.")
            .MaximumLength(50)
            .WithMessage("Order number must not exceed 50 characters.");

        RuleFor(x => x.TotalAmount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Total amount cannot be negative.");
    }
}