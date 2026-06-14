using OrganicDesignPatterns.Application.DTOs.OrderValidation;
using OrganicDesignPatterns.Domain.Enums;

namespace OrganicDesignPatterns.Application.DesignPatterns.ChainOfResponsibility;

public class OrderValidationRequest
{
    public string CustomerName { get; set; } = string.Empty;

    public string CustomerEmail { get; set; } = string.Empty;

    public string ShippingAddress { get; set; } = string.Empty;

    public PaymentMethod? PaymentMethod { get; set; }

    public List<OrderValidationItemDto> Items { get; set; } = new();
}