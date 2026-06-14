using OrganicDesignPatterns.Domain.Common;

namespace OrganicDesignPatterns.Domain.Entities;

public class Customer : BaseEntity
{
    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();

    public ICollection<Basket> Baskets { get; set; } = new List<Basket>();
}