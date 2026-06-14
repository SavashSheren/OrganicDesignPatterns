namespace OrganicDesignPatterns.Application.DesignPatterns.ChainOfResponsibility;

public class OrderValidationChainBuilder
{
    public OrderValidationHandler Build()
    {
        var customerInfoHandler = new CustomerInfoValidationHandler();
        var basketHandler = new BasketValidationHandler();
        var stockHandler = new StockValidationHandler();
        var paymentHandler = new PaymentValidationHandler();
        var shippingAddressHandler = new ShippingAddressValidationHandler();

        customerInfoHandler
            .SetNext(basketHandler)
            .SetNext(stockHandler)
            .SetNext(paymentHandler)
            .SetNext(shippingAddressHandler);

        return customerInfoHandler;
    }
}