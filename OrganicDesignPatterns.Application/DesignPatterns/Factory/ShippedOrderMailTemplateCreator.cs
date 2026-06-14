using OrganicDesignPatterns.Domain.Enums;

namespace OrganicDesignPatterns.Application.DesignPatterns.Factory;

public class ShippedOrderMailTemplateCreator : MailTemplateCreator
{
    public override OrderStatus OrderStatus => OrderStatus.Shipped;

    public override IMailTemplate CreateTemplate()
    {
        return new ShippedOrderMailTemplate();
    }
}