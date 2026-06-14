namespace OrganicDesignPatterns.Application.DTOs.Shipping;

public class ShippingCalculationResultDto
{
    public decimal BaseShippingPrice { get; set; }

    public decimal TotalShippingPrice { get; set; }

    public List<string> AppliedServices { get; set; } = new();
}