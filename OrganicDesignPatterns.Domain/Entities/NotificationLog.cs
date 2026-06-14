using OrganicDesignPatterns.Domain.Common;

namespace OrganicDesignPatterns.Domain.Entities;

public class NotificationLog : BaseEntity
{
    public string NotificationType { get; set; } = string.Empty;

    public string Recipient { get; set; } = string.Empty;

    public string Subject { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;

    public bool IsSuccess { get; set; }

    public string? ErrorMessage { get; set; }

    public DateTime SentDate { get; set; } = DateTime.Now;
}