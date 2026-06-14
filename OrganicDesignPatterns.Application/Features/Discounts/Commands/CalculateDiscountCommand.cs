using MediatR;
using OrganicDesignPatterns.Application.DesignPatterns.Strategy;
using OrganicDesignPatterns.Application.DTOs.Discounts;
using OrganicDesignPatterns.Domain.Enums;

namespace OrganicDesignPatterns.Application.Features.Discounts.Commands;

public class CalculateDiscountCommand : IRequest<DiscountCalculationResultDto>
{
    public DiscountType DiscountType { get; set; }

    public decimal OrderTotal { get; set; }

    public decimal DiscountValue { get; set; }
}

public class CalculateDiscountCommandHandler : IRequestHandler<CalculateDiscountCommand, DiscountCalculationResultDto>
{
    private readonly DiscountStrategyContext _discountStrategyContext;

    public CalculateDiscountCommandHandler(DiscountStrategyContext discountStrategyContext)
    {
        _discountStrategyContext = discountStrategyContext;
    }

    public Task<DiscountCalculationResultDto> Handle(
        CalculateDiscountCommand request,
        CancellationToken cancellationToken)
    {
        var discountAmount = _discountStrategyContext.CalculateDiscount(
            request.DiscountType,
            request.OrderTotal,
            request.DiscountValue);

        var finalTotal = request.OrderTotal - discountAmount;

        var result = new DiscountCalculationResultDto
        {
            DiscountType = request.DiscountType,
            OrderTotal = request.OrderTotal,
            DiscountValue = request.DiscountValue,
            DiscountAmount = discountAmount,
            FinalTotal = finalTotal
        };

        return Task.FromResult(result);
    }
}