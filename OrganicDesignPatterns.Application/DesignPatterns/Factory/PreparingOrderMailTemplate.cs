namespace OrganicDesignPatterns.Application.DesignPatterns.Factory;

public class PreparingOrderMailTemplate : IMailTemplate
{
    public string TemplateName => "Preparing Order Template";

    public string GenerateSubject(MailTemplateRequest request)
    {
        return $"Order Is Being Prepared - {request.OrderNumber}";
    }

    public string GenerateBody(MailTemplateRequest request)
    {
        return $"Hello {request.CustomerName}, your order {request.OrderNumber} is now being prepared with fresh organic products.";
    }
}