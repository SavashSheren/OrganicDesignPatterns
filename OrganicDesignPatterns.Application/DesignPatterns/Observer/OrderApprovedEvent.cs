namespace OrganicDesignPatterns.Application.DesignPatterns.Observer;

public class OrderApprovedEvent
{
    public string OrderNumber { get; set; } = string.Empty;

    public string CustomerName { get; set; } = string.Empty;

    public string CustomerEmail { get; set; } = string.Empty;

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal TotalAmount { get; set; }
}