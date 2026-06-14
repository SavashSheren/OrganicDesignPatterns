using OrganicDesignPatterns.Domain.Enums;

namespace OrganicDesignPatterns.Application.DesignPatterns.Factory;

public class PendingOrderMailTemplateCreator : MailTemplateCreator
{
    public override OrderStatus OrderStatus => OrderStatus.Pending;

    public override IMailTemplate CreateTemplate()
    {
        return new PendingOrderMailTemplate();
    }
}
