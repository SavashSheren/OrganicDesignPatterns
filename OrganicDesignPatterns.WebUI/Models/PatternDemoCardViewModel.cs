namespace OrganicDesignPatterns.WebUI.Models;

public class PatternDemoCardViewModel
{
    public string PatternName { get; set; } = string.Empty;

    public string ScenarioName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Endpoint { get; set; } = string.Empty;

    public string RequestSample { get; set; } = string.Empty;

    public string ResponseSample { get; set; } = string.Empty;

    public string BadgeText { get; set; } = "Completed";
}