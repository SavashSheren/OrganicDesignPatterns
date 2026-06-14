using OrganicDesignPatterns.Application.DTOs.OrderValidation;

namespace OrganicDesignPatterns.Application.DesignPatterns.ChainOfResponsibility;

public class OrderValidationContext
{
    public OrderValidationRequest Request { get; }

    public List<OrderValidationStepResultDto> Steps { get; } = new();

    public bool IsValid => Steps.All(x => x.IsSuccess);

    public OrderValidationContext(OrderValidationRequest request)
    {
        Request = request;
    }

    public void AddStep(string handlerName, bool isSuccess, string message)
    {
        Steps.Add(new OrderValidationStepResultDto
        {
            HandlerName = handlerName,
            IsSuccess = isSuccess,
            Message = message
        });
    }
}