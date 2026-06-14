namespace OrganicDesignPatterns.Application.DTOs.OrderEvents;

public class OrderObserverResultDto
{
    public string ObserverName { get; set; } = string.Empty;

    public bool IsSuccess { get; set; }

    public string Message { get; set; } = string.Empty;
}