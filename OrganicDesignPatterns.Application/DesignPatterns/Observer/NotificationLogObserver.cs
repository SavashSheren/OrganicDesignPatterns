using OrganicDesignPatterns.Application.DTOs.OrderEvents;
using OrganicDesignPatterns.Domain.Entities;
using OrganicDesignPatterns.Domain.Interfaces;

namespace OrganicDesignPatterns.Application.DesignPatterns.Observer;

public class NotificationLogObserver : IOrderApprovedObserver
{
    private readonly IUnitOfWork _unitOfWork;

    public NotificationLogObserver(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OrderObserverResultDto> HandleAsync(
        OrderApprovedEvent orderApprovedEvent,
        CancellationToken cancellationToken)
    {
        var notificationLog = new NotificationLog
        {
            NotificationType = "OrderApproved",
            Recipient = orderApprovedEvent.CustomerEmail,
            Subject = $"Order Approved - {orderApprovedEvent.OrderNumber}",
            Message = $"Order {orderApprovedEvent.OrderNumber} approved for {orderApprovedEvent.CustomerName}.",
            IsSuccess = true,
            SentDate = DateTime.Now
        };

        await _unitOfWork.NotificationLogs.AddAsync(notificationLog);

        return new OrderObserverResultDto
        {
            ObserverName = nameof(NotificationLogObserver),
            IsSuccess = true,
            Message = "Notification log created successfully."
        };
    }
}