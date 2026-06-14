using OrganicDesignPatterns.Domain.Enums;

namespace OrganicDesignPatterns.Application.DesignPatterns.Factory;

public class ApprovedOrderMailTemplateCreator : MailTemplateCreator
{
    public override OrderStatus OrderStatus => OrderStatus.Approved;

    public override IMailTemplate CreateTemplate()
    {
        return new ApprovedOrderMailTemplate();
    }
}