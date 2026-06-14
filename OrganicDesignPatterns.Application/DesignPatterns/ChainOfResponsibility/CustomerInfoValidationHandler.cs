namespace OrganicDesignPatterns.Application.DesignPatterns.ChainOfResponsibility;

public class CustomerInfoValidationHandler : OrderValidationHandler
{
    protected override Task<bool> ValidateAsync(
        OrderValidationContext context,
        CancellationToken cancellationToken)
    {
        var request = context.Request;

        if (string.IsNullOrWhiteSpace(request.CustomerName))
        {
            context.AddStep(
                nameof(CustomerInfoValidationHandler),
                false,
                "Customer name is required.");

            return Task.FromResult(false);
        }

        if (string.IsNullOrWhiteSpace(request.CustomerEmail))
        {
            context.AddStep(
                nameof(CustomerInfoValidationHandler),
                false,
                "Customer email is required.");

            return Task.FromResult(false);
        }

        if (!request.CustomerEmail.Contains("@"))
        {
            context.AddStep(
                nameof(CustomerInfoValidationHandler),
                false,
                "Customer email is not valid.");

            return Task.FromResult(false);
        }

        context.AddStep(
            nameof(CustomerInfoValidationHandler),
            true,
            "Customer information is valid.");

        return Task.FromResult(true);
    }
}