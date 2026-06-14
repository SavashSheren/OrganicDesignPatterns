using OrganicDesignPatterns.Domain.Enums;

namespace OrganicDesignPatterns.Application.DesignPatterns.Factory;

public class MailTemplateRequest
{
    public OrderStatus OrderStatus { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public string OrderNumber { get; set; } = string.Empty;

    public decimal TotalAmount { get; set; }
}