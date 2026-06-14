namespace OrganicDesignPatterns.Application.DesignPatterns.Factory;

public class PendingOrderMailTemplate : IMailTemplate
{
    public string TemplateName => "Pending Order Template";

    public string GenerateSubject(MailTemplateRequest request)
    {
        return $"Order Received - {request.OrderNumber}";
    }

    public string GenerateBody(MailTemplateRequest request)
    {
        return $"Hello {request.CustomerName}, your order {request.OrderNumber} has been received and is waiting for approval. Total amount: {request.TotalAmount:C}.";
    }
}