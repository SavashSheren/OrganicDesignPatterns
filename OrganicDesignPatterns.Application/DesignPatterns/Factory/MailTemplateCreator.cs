using OrganicDesignPatterns.Domain.Enums;

namespace OrganicDesignPatterns.Application.DesignPatterns.Factory;

public abstract class MailTemplateCreator
{
    public abstract OrderStatus OrderStatus { get; }

    public abstract IMailTemplate CreateTemplate();
}