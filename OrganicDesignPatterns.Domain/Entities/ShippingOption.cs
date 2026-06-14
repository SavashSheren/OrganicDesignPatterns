using OrganicDesignPatterns.Domain.Common;

namespace OrganicDesignPatterns.Domain.Entities;

public class ShippingOption : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public decimal BasePrice { get; set; }

    public bool IsActive { get; set; } = true;
}