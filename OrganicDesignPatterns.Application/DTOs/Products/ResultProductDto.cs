namespace OrganicDesignPatterns.Application.DTOs.Products;

public class ResultProductDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public decimal? DiscountedPrice { get; set; }

    public int Stock { get; set; }

    public string? ImageUrl { get; set; }

    public bool IsFeatured { get; set; }

    public bool IsActive { get; set; }

    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }
}