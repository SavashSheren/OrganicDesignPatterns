namespace OrganicDesignPatterns.WebUI.Models;

public class ProductCardViewModel
{
    public string Name { get; set; } = string.Empty;

    public string CategoryName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public decimal? DiscountedPrice { get; set; }

    public int Stock { get; set; }

    public bool IsFeatured { get; set; }

    public string ImageUrl { get; set; } = string.Empty;
}