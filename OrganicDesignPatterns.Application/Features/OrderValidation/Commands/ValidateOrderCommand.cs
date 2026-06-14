using MediatR;
using OrganicDesignPatterns.Application.DesignPatterns.ChainOfResponsibility;
using OrganicDesignPatterns.Application.DTOs.OrderValidation;
using OrganicDesignPatterns.Domain.Enums;

namespace OrganicDesignPatterns.Application.Features.OrderValidation.Commands;

public class ValidateOrderCommand : IRequest<OrderValidationResultDto>
{
    public string CustomerName { get; set; } = string.Empty;

    public string CustomerEmail { get; set; } = string.Empty;

    public string ShippingAddress { get; set; } = string.Empty;

    public PaymentMethod? PaymentMethod { get; set; }

    public List<OrderValidationItemDto> Items { get; set; } = new();
}

public class ValidateOrderCommandHandler : IRequestHandler<ValidateOrderCommand, OrderValidationResultDto>
{
    private readonly OrderValidationChainBuilder _chainBuilder;

    public ValidateOrderCommandHandler(OrderValidationChainBuilder chainBuilder)
    {
        _chainBuilder = chainBuilder;
    }

    public async Task<OrderValidationResultDto> Handle(
        ValidateOrderCommand request,
        CancellationToken cancellationToken)
    {
        var validationRequest = new OrderValidationRequest
        {
            CustomerName = request.CustomerName,
            CustomerEmail = request.CustomerEmail,
            ShippingAddress = request.ShippingAddress,
            PaymentMethod = request.PaymentMethod,
            Items = request.Items
        };

        var context = new OrderValidationContext(validationRequest);

        var chain = _chainBuilder.Build();

        await chain.HandleAsync(context, cancellationToken);

        return new OrderValidationResultDto
        {
            IsValid = context.IsValid,
            Steps = context.Steps
        };
    }
}