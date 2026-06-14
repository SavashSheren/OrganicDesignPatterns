namespace OrganicDesignPatterns.Application.DesignPatterns.Decorator;

public interface IShippingCostCalculator
{
    decimal CalculateCost();

    List<string> GetAppliedServices();
}