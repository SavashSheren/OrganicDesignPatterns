using MediatR;
using OrganicDesignPatterns.Application.DesignPatterns.Decorator;
using OrganicDesignPatterns.Application.DTOs.Shipping;

namespace OrganicDesignPatterns.Application.Features.Shipping.Commands;

public class CalculateShippingCommand : IRequest<ShippingCalculationResultDto>
{
    public decimal BaseShippingPrice { get; set; }

    public bool FastDelivery { get; set; }

    public bool GiftPackage { get; set; }

    public bool ColdChainPackage { get; set; }
}

public class CalculateShippingCommandHandler : IRequestHandler<CalculateShippingCommand, ShippingCalculationResultDto>
{
    public Task<ShippingCalculationResultDto> Handle(
        CalculateShippingCommand request,
        CancellationToken cancellationToken)
    {
        IShippingCostCalculator calculator =
            new BaseShippingCostCalculator(request.BaseShippingPrice);

        if (request.FastDelivery)
        {
            calculator = new FastDeliveryDecorator(calculator);
        }

        if (request.GiftPackage)
        {
            calculator = new GiftPackageDecorator(calculator);
        }

        if (request.ColdChainPackage)
        {
            calculator = new ColdChainPackageDecorator(calculator);
        }

        var result = new ShippingCalculationResultDto
        {
            BaseShippingPrice = request.BaseShippingPrice,
            TotalShippingPrice = calculator.CalculateCost(),
            AppliedServices = calculator.GetAppliedServices()
        };

        return Task.FromResult(result);
    }
}