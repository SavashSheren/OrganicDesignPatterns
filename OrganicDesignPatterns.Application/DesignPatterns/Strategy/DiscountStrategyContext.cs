using OrganicDesignPatterns.Domain.Enums;

namespace OrganicDesignPatterns.Application.DesignPatterns.Strategy;

public class DiscountStrategyContext
{
    private readonly IEnumerable<IDiscountStrategy> _discountStrategies;

    public DiscountStrategyContext(IEnumerable<IDiscountStrategy> discountStrategies)
    {
        _discountStrategies = discountStrategies;
    }

    public decimal CalculateDiscount(DiscountType discountType, decimal orderTotal, decimal discountValue)
    {
        var strategy = _discountStrategies.FirstOrDefault(x => x.DiscountType == discountType);

        if (strategy is null)
        {
            throw new InvalidOperationException("Discount strategy not found.");
        }

        return strategy.CalculateDiscount(orderTotal, discountValue);
    }
}