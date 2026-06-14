namespace OrganicDesignPatterns.Application.DesignPatterns.Decorator;

public class FastDeliveryDecorator : ShippingCostDecorator
{
    private const decimal ExtraPrice = 30;

    public FastDeliveryDecorator(IShippingCostCalculator shippingCostCalculator)
        : base(shippingCostCalculator)
    {
    }

    public override decimal CalculateCost()
    {
        return ShippingCostCalculator.CalculateCost() + ExtraPrice;
    }

    public override List<string> GetAppliedServices()
    {
        var services = ShippingCostCalculator.GetAppliedServices();
        services.Add("Fast Delivery (+30)");
        return services;
    }
}