using OrganicDesignPatterns.Application.DTOs.OrderEvents;

namespace OrganicDesignPatterns.Application.DesignPatterns.Observer;

public class OrderApprovedSubject : IOrderApprovedSubject
{
    private readonly IEnumerable<IOrderApprovedObserver> _observers;

    public OrderApprovedSubject(IEnumerable<IOrderApprovedObserver> observers)
    {
        _observers = observers;
    }

    public async Task<List<OrderObserverResultDto>> NotifyAsync(
        OrderApprovedEvent orderApprovedEvent,
        CancellationToken cancellationToken)
    {
        var results = new List<OrderObserverResultDto>();

        foreach (var observer in _observers)
        {
            var result = await observer.HandleAsync(orderApprovedEvent, cancellationToken);
            results.Add(result);
        }

        return results;
    }
}