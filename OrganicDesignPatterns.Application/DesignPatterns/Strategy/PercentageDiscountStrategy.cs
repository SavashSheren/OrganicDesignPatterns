using OrganicDesignPatterns.Domain.Enums;

namespace OrganicDesignPatterns.Application.DesignPatterns.Strategy;

public class PercentageDiscountStrategy : IDiscountStrategy
{
    public DiscountType DiscountType => DiscountType.Percentage;

    public decimal CalculateDiscount(decimal orderTotal, decimal discountValue)
    {
        return orderTotal * discountValue / 100;
    }
}