using OrganicDesignPatterns.Domain.Enums;

namespace OrganicDesignPatterns.Application.DesignPatterns.Factory;

public class MailTemplateFactoryContext
{
    private readonly IEnumerable<MailTemplateCreator> _creators;

    public MailTemplateFactoryContext(IEnumerable<MailTemplateCreator> creators)
    {
        _creators = creators;
    }

    public IMailTemplate CreateTemplate(OrderStatus orderStatus)
    {
        var creator = _creators.FirstOrDefault(x => x.OrderStatus == orderStatus);

        if (creator is null)
        {
            throw new InvalidOperationException("Mail template creator not found.");
        }

        return creator.CreateTemplate();
    }
}