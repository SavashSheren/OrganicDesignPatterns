namespace OrganicDesignPatterns.Application.DesignPatterns.Factory;

public class ApprovedOrderMailTemplate : IMailTemplate
{
    public string TemplateName => "Approved Order Template";

    public string GenerateSubject(MailTemplateRequest request)
    {
        return $"Order Approved - {request.OrderNumber}";
    }

    public string GenerateBody(MailTemplateRequest request)
    {
        return $"Hello {request.CustomerName}, your order {request.OrderNumber} has been approved. We are preparing your organic products.";
    }
}