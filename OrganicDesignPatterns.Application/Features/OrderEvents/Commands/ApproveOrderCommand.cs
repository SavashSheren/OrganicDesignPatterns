using MediatR;
using OrganicDesignPatterns.Application.DesignPatterns.Observer;
using OrganicDesignPatterns.Application.DTOs.OrderEvents;
using OrganicDesignPatterns.Domain.Interfaces;

namespace OrganicDesignPatterns.Application.Features.OrderEvents.Commands;

public class ApproveOrderCommand : IRequest<ApproveOrderResultDto>
{
    public string OrderNumber { get; set; } = string.Empty;

    public string CustomerName { get; set; } = string.Empty;

    public string CustomerEmail { get; set; } = string.Empty;

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal TotalAmount { get; set; }
}

public class ApproveOrderCommandHandler : IRequestHandler<ApproveOrderCommand, ApproveOrderResultDto>
{
    private readonly IOrderApprovedSubject _orderApprovedSubject;
    private readonly IUnitOfWork _unitOfWork;

    public ApproveOrderCommandHandler(
        IOrderApprovedSubject orderApprovedSubject,
        IUnitOfWork unitOfWork)
    {
        _orderApprovedSubject = orderApprovedSubject;
        _unitOfWork = unitOfWork;
    }

    public async Task<ApproveOrderResultDto> Handle(
        ApproveOrderCommand request,
        CancellationToken cancellationToken)
    {
        var orderApprovedEvent = new OrderApprovedEvent
        {
            OrderNumber = request.OrderNumber,
            CustomerName = request.CustomerName,
            CustomerEmail = request.CustomerEmail,
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            TotalAmount = request.TotalAmount
        };

        var observerResults = await _orderApprovedSubject.NotifyAsync(
            orderApprovedEvent,
            cancellationToken);

        await _unitOfWork.SaveChangesAsync();

        return new ApproveOrderResultDto
        {
            OrderNumber = request.OrderNumber,
            CustomerEmail = request.CustomerEmail,
            IsSuccessful = observerResults.All(x => x.IsSuccess),
            ObserverResults = observerResults
        };
    }
}