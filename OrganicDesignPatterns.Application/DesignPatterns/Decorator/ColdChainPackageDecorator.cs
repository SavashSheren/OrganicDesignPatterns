namespace OrganicDesignPatterns.Application.DesignPatterns.Decorator;

public class ColdChainPackageDecorator : ShippingCostDecorator
{
    private const decimal ExtraPrice = 40;

    public ColdChainPackageDecorator(IShippingCostCalculator shippingCostCalculator)
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
        services.Add("Cold Chain Package (+40)");
        return services;
    }
}