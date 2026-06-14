namespace OrganicDesignPatterns.Application.DTOs.OrderValidation;

public class OrderValidationStepResultDto
{
    public string HandlerName { get; set; } = string.Empty;

    public bool IsSuccess { get; set; }

    public string Message { get; set; } = string.Empty;
}