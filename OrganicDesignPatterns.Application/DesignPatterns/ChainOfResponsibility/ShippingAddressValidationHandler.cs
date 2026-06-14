namespace OrganicDesignPatterns.Application.DesignPatterns.ChainOfResponsibility;

public class ShippingAddressValidationHandler : OrderValidationHandler
{
    protected override Task<bool> ValidateAsync(
        OrderValidationContext context,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(context.Request.ShippingAddress))
        {
            context.AddStep(
                nameof(ShippingAddressValidationHandler),
                false,
                "Shipping address is required.");

            return Task.FromResult(false);
        }

        if (context.Request.ShippingAddress.Length < 10)
        {
            context.AddStep(
                nameof(ShippingAddressValidationHandler),
                false,
                "Shipping address must be at least 10 characters.");

            return Task.FromResult(false);
        }

        context.AddStep(
            nameof(ShippingAddressValidationHandler),
            true,
            "Shipping address is valid.");

        return Task.FromResult(true);
    }
}