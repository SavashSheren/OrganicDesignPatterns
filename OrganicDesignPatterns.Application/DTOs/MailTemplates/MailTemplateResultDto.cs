using OrganicDesignPatterns.Domain.Enums;

namespace OrganicDesignPatterns.Application.DTOs.MailTemplates;

public class MailTemplateResultDto
{
    public OrderStatus OrderStatus { get; set; }

    public string TemplateName { get; set; } = string.Empty;

    public string Subject { get; set; } = string.Empty;

    public string Body { get; set; } = string.Empty;
}