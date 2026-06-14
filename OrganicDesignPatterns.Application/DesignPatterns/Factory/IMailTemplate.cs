namespace OrganicDesignPatterns.Application.DesignPatterns.Factory;

public interface IMailTemplate
{
    string TemplateName { get; }

    string GenerateSubject(MailTemplateRequest request);

    string GenerateBody(MailTemplateRequest request);
}