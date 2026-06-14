using OrganicDesignPatterns.Domain.Enums;

namespace OrganicDesignPatterns.Application.DesignPatterns.Factory;

public class DeliveredOrderMailTemplateCreator : MailTemplateCreator
{
    public override OrderStatus OrderStatus => OrderStatus.Delivered;

    public override IMailTemplate CreateTemplate()
    {
        return new DeliveredOrderMailTemplate();
    }
}