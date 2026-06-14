namespace OrganicDesignPatterns.Application.DesignPatterns.Decorator;

public class BaseShippingCostCalculator : IShippingCostCalculator
{
    private readonly decimal _basePrice;

    public BaseShippingCostCalculator(decimal basePrice)
    {
        _basePrice = basePrice;
    }

    public decimal CalculateCost()
    {
        return _basePrice;
    }

    public List<string> GetAppliedServices()
    {
        return new List<string> { "Standard Shipping" };
    }
}