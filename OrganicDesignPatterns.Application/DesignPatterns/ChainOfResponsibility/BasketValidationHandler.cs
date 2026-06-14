namespace OrganicDesignPatterns.Application.DesignPatterns.ChainOfResponsibility;

public class BasketValidationHandler : OrderValidationHandler
{
    protected override Task<bool> ValidateAsync(
        OrderValidationContext context,
        CancellationToken cancellationToken)
    {
        if (context.Request.Items is null || !context.Request.Items.Any())
        {
            context.AddStep(
                nameof(BasketValidationHandler),
                false,
                "Basket cannot be empty.");

            return Task.FromResult(false);
        }

        context.AddStep(
            nameof(BasketValidationHandler),
            true,
            "Basket contains product items.");

        return Task.FromResult(true);
    }
}