using OrganicDesignPatterns.Application.DTOs.OrderEvents;

namespace OrganicDesignPatterns.Application.DesignPatterns.Observer;

public class EmailNotificationObserver : IOrderApprovedObserver
{
    public Task<OrderObserverResultDto> HandleAsync(
        OrderApprovedEvent orderApprovedEvent,
        CancellationToken cancellationToken)
    {
        var result = new OrderObserverResultDto
        {
            ObserverName = nameof(EmailNotificationObserver),
            IsSuccess = true,
            Message = $"Email notification simulated for {orderApprovedEvent.CustomerEmail}. Order: {orderApprovedEvent.OrderNumber}"
        };

        return Task.FromResult(result);
    }
}