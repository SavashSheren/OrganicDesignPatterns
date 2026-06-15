namespace OrganicDesignPatterns.WebUI.Models;

public class CategoryCardViewModel
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string BadgeText { get; set; } = string.Empty;

    public string PatternName { get; set; } = string.Empty;

    public string ScenarioDescription { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;
}