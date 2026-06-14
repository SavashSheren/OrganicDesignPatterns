namespace OrganicDesignPatterns.Application.DesignPatterns.Factory;

public class DeliveredOrderMailTemplate : IMailTemplate
{
    public string TemplateName => "Delivered Order Template";

    public string GenerateSubject(MailTemplateRequest request)
    {
        return $"Order Delivered - {request.OrderNumber}";
    }

    public string GenerateBody(MailTemplateRequest request)
    {
        return $"Hello {request.CustomerName}, your order {request.OrderNumber} has been delivered. Thank you for choosing our organic store.";
    }
}