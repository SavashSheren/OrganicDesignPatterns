namespace OrganicDesignPatterns.Application.DTOs.OrderValidation;

public class OrderValidationItemDto
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public int RequestedQuantity { get; set; }

    public int AvailableStock { get; set; }
}