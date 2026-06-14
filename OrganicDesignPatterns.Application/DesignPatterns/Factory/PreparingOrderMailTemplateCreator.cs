using OrganicDesignPatterns.Domain.Enums;

namespace OrganicDesignPatterns.Application.DesignPatterns.Factory;

public class PreparingOrderMailTemplateCreator : MailTemplateCreator
{
    public override OrderStatus OrderStatus => OrderStatus.Preparing;

    public override IMailTemplate CreateTemplate()
    {
        return new PreparingOrderMailTemplate();
    }
}