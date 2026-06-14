namespace OrganicDesignPatterns.Application.DesignPatterns.ChainOfResponsibility;

public class PaymentValidationHandler : OrderValidationHandler
{
    protected override Task<bool> ValidateAsync(
        OrderValidationContext context,
        CancellationToken cancellationToken)
    {
        if (context.Request.PaymentMethod is null)
        {
            context.AddStep(
                nameof(PaymentValidationHandler),
                false,
                "Payment method is required.");

            return Task.FromResult(false);
        }

        context.AddStep(
            nameof(PaymentValidationHandler),
            true,
            "Payment method is selected.");

        return Task.FromResult(true);
    }
}