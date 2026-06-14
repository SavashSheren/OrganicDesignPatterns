using OrganicDesignPatterns.Domain.Enums;

namespace OrganicDesignPatterns.Application.DesignPatterns.Factory;

public class CancelledOrderMailTemplateCreator : MailTemplateCreator
{
    public override OrderStatus OrderStatus => OrderStatus.Cancelled;

    public override IMailTemplate CreateTemplate()
    {
        return new CancelledOrderMailTemplate();
    }
}