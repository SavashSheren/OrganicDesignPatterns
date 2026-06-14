namespace OrganicDesignPatterns.Application.DesignPatterns.ChainOfResponsibility;

public abstract class OrderValidationHandler
{
    private OrderValidationHandler? _nextHandler;

    public OrderValidationHandler SetNext(OrderValidationHandler nextHandler)
    {
        _nextHandler = nextHandler;
        return nextHandler;
    }

    public async Task HandleAsync(
        OrderValidationContext context,
        CancellationToken cancellationToken)
    {
        var canContinue = await ValidateAsync(context, cancellationToken);

        if (canContinue && _nextHandler is not null)
        {
            await _nextHandler.HandleAsync(context, cancellationToken);
        }
    }

    protected abstract Task<bool> ValidateAsync(
        OrderValidationContext context,
        CancellationToken cancellationToken);
}