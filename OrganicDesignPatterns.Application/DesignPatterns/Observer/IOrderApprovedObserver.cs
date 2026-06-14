using OrganicDesignPatterns.Application.DTOs.OrderEvents;

namespace OrganicDesignPatterns.Application.DesignPatterns.Observer;

public interface IOrderApprovedObserver
{
    Task<OrderObserverResultDto> HandleAsync(
        OrderApprovedEvent orderApprovedEvent,
        CancellationToken cancellationToken);
}