namespace OrganicDesignPatterns.Application.DesignPatterns.Decorator;

public abstract class ShippingCostDecorator : IShippingCostCalculator
{
    protected readonly IShippingCostCalculator ShippingCostCalculator;

    protected ShippingCostDecorator(IShippingCostCalculator shippingCostCalculator)
    {
        ShippingCostCalculator = shippingCostCalculator;
    }

    public abstract decimal CalculateCost();

    public abstract List<string> GetAppliedServices();
}