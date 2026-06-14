namespace OrganicDesignPatterns.Application.DesignPatterns.Decorator;

public class GiftPackageDecorator : ShippingCostDecorator
{
    private const decimal ExtraPrice = 20;

    public GiftPackageDecorator(IShippingCostCalculator shippingCostCalculator)
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
        services.Add("Gift Package (+20)");
        return services;
    }
}