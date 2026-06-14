namespace OrganicDesignPatterns.Application.DTOs.OrderEvents;

public class ApproveOrderResultDto
{
    public string OrderNumber { get; set; } = string.Empty;

    public string CustomerEmail { get; set; } = string.Empty;

    public bool IsSuccessful { get; set; }

    public List<OrderObserverResultDto> ObserverResults { get; set; } = new();
}