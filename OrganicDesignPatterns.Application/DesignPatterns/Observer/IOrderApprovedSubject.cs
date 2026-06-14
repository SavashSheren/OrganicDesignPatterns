using OrganicDesignPatterns.Application.DTOs.OrderEvents;

namespace OrganicDesignPatterns.Application.DesignPatterns.Observer;

public interface IOrderApprovedSubject
{
    Task<List<OrderObserverResultDto>> NotifyAsync(
        OrderApprovedEvent orderApprovedEvent,
        CancellationToken cancellationToken);
}