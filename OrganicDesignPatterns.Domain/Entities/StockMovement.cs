using OrganicDesignPatterns.Domain.Common;

namespace OrganicDesignPatterns.Domain.Entities;

public class StockMovement : BaseEntity
{
    public int ProductId { get; set; }

    public Product? Product { get; set; }

    public int Quantity { get; set; }

    public string MovementType { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime MovementDate { get; set; } = DateTime.Now;
}