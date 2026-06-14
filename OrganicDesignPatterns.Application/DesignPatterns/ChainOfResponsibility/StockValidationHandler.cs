namespace OrganicDesignPatterns.Application.DesignPatterns.ChainOfResponsibility;

public class StockValidationHandler : OrderValidationHandler
{
    protected override Task<bool> ValidateAsync(
        OrderValidationContext context,
        CancellationToken cancellationToken)
    {
        foreach (var item in context.Request.Items)
        {
            if (item.RequestedQuantity <= 0)
            {
                context.AddStep(
                    nameof(StockValidationHandler),
                    false,
                    $"Requested quantity must be greater than zero for product {item.ProductName}.");

                return Task.FromResult(false);
            }

            if (item.AvailableStock < item.RequestedQuantity)
            {
                context.AddStep(
                    nameof(StockValidationHandler),
                    false,
                    $"Insufficient stock for product {item.ProductName}. Requested: {item.RequestedQuantity}, Available: {item.AvailableStock}.");

                return Task.FromResult(false);
            }
        }

        context.AddStep(
            nameof(StockValidationHandler),
            true,
            "Product stocks are sufficient.");

        return Task.FromResult(true);
    }
}