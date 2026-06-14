using OrganicDesignPatterns.Domain.Common;

namespace OrganicDesignPatterns.Domain.Entities;

public class Basket : BaseEntity
{
    public int CustomerId { get; set; }

    public Customer? Customer { get; set; }

    public ICollection<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
}