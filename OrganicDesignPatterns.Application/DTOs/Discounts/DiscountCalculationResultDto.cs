using OrganicDesignPatterns.Domain.Enums;

namespace OrganicDesignPatterns.Application.DTOs.Discounts;

public class DiscountCalculationResultDto
{
    public DiscountType DiscountType { get; set; }

    public decimal OrderTotal { get; set; }

    public decimal DiscountValue { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal FinalTotal { get; set; }
}