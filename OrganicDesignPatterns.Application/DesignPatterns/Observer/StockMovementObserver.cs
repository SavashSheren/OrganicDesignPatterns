using OrganicDesignPatterns.Application.DTOs.OrderEvents;
using OrganicDesignPatterns.Domain.Entities;
using OrganicDesignPatterns.Domain.Interfaces;

namespace OrganicDesignPatterns.Application.DesignPatterns.Observer;

public class StockMovementObserver : IOrderApprovedObserver
{
    private readonly IUnitOfWork _unitOfWork;

    public StockMovementObserver(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OrderObserverResultDto> HandleAsync(
        OrderApprovedEvent orderApprovedEvent,
        CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(orderApprovedEvent.ProductId);

        if (product is null)
        {
            return new OrderObserverResultDto
            {
                ObserverName = nameof(StockMovementObserver),
                IsSuccess = false,
                Message = "Product not found. Stock movement could not be created."
            };
        }

        if (product.Stock < orderApprovedEvent.Quantity)
        {
            return new OrderObserverResultDto
            {
                ObserverName = nameof(StockMovementObserver),
                IsSuccess = false,
                Message = "Insufficient stock. Stock movement could not be created."
            };
        }

        product.Stock -= orderApprovedEvent.Quantity;

        var stockMovement = new StockMovement
        {
            ProductId = product.Id,
            Quantity = orderApprovedEvent.Quantity,
            MovementType = "Decrease",
            Description = $"Stock decreased after order approval. Order: {orderApprovedEvent.OrderNumber}",
            MovementDate = DateTime.Now
        };

        _unitOfWork.Products.Update(product);
        await _unitOfWork.StockMovements.AddAsync(stockMovement);

        return new OrderObserverResultDto
        {
            ObserverName = nameof(StockMovementObserver),
            IsSuccess = true,
            Message = $"Stock decreased by {orderApprovedEvent.Quantity} for product {product.Name}."
        };
    }
}