using OrganicDesignPatterns.Domain.Enums;

namespace OrganicDesignPatterns.Application.DesignPatterns.Strategy;

public interface IDiscountStrategy
{
    DiscountType DiscountType { get; }

    decimal CalculateDiscount(decimal orderTotal, decimal discountValue);
}