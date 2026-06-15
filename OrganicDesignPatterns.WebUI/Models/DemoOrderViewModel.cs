namespace OrganicDesignPatterns.WebUI.Models;

public class DemoOrderViewModel
{
    public string OrderNumber { get; set; } = string.Empty;

    public string CustomerName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string ShippingAddress { get; set; } = string.Empty;

    public string PaymentMethod { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; }

    public decimal TotalPrice { get; set; }

    public string Status { get; set; } = "Pending";

    public List<BasketItemViewModel> Items { get; set; } = new();
}