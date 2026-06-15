namespace OrganicDesignPatterns.WebUI.Models;

public class CheckoutViewModel
{
    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string ShippingAddress { get; set; } = string.Empty;

    public string PaymentMethod { get; set; } = "Credit Card";

    public List<BasketItemViewModel> BasketItems { get; set; } = new();

    public decimal Subtotal { get; set; }

    public decimal ShippingCost { get; set; }

    public decimal TotalPrice { get; set; }
}