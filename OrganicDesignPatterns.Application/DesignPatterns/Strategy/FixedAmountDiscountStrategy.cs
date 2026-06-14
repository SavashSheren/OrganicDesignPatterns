using OrganicDesignPatterns.Domain.Enums;

namespace OrganicDesignPatterns.Application.DesignPatterns.Strategy;

public class FixedAmountDiscountStrategy : IDiscountStrategy
{
    public DiscountType DiscountType => DiscountType.FixedAmount;

    public decimal CalculateDiscount(decimal orderTotal, decimal discountValue)
    {
        return discountValue > orderTotal ? orderTotal : discountValue;
    }
}