using OrganicDesignPatterns.Domain.Common;
using OrganicDesignPatterns.Domain.Enums;

namespace OrganicDesignPatterns.Domain.Entities;

public class Order : BaseEntity
{
    public string OrderNumber { get; set; } = string.Empty;

    public int CustomerId { get; set; }

    public Customer? Customer { get; set; }

    public DateTime OrderDate { get; set; } = DateTime.Now;

    public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;

    public PaymentMethod PaymentMethod { get; set; }

    public decimal SubTotal { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal ShippingPrice { get; set; }

    public decimal TotalAmount { get; set; }

    public string? ShippingAddress { get; set; }

    public string? Note { get; set; }

    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}