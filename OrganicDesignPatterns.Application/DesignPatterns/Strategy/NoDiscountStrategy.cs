using OrganicDesignPatterns.Domain.Enums;

namespace OrganicDesignPatterns.Application.DesignPatterns.Strategy;

public class NoDiscountStrategy : IDiscountStrategy
{
    public DiscountType DiscountType => DiscountType.None;

    public decimal CalculateDiscount(decimal orderTotal, decimal discountValue)
    {
        return 0;
    }
}