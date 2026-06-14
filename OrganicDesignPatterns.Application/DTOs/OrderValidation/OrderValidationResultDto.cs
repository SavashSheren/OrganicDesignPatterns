namespace OrganicDesignPatterns.Application.DTOs.OrderValidation;

public class OrderValidationResultDto
{
    public bool IsValid { get; set; }

    public List<OrderValidationStepResultDto> Steps { get; set; } = new();
}