namespace OrganicDesignPatterns.Application.DesignPatterns.Factory;

public class CancelledOrderMailTemplate : IMailTemplate
{
    public string TemplateName => "Cancelled Order Template";

    public string GenerateSubject(MailTemplateRequest request)
    {
        return $"Order Cancelled - {request.OrderNumber}";
    }

    public string GenerateBody(MailTemplateRequest request)
    {
        return $"Hello {request.CustomerName}, your order {request.OrderNumber} has been cancelled. If this was a mistake, please contact support.";
    }
}