namespace OrganicDesignPatterns.Application.DesignPatterns.Factory;

public class ShippedOrderMailTemplate : IMailTemplate
{
    public string TemplateName => "Shipped Order Template";

    public string GenerateSubject(MailTemplateRequest request)
    {
        return $"Order Shipped - {request.OrderNumber}";
    }

    public string GenerateBody(MailTemplateRequest request)
    {
        return $"Hello {request.CustomerName}, your order {request.OrderNumber} has been shipped. It will arrive soon.";
    }
}