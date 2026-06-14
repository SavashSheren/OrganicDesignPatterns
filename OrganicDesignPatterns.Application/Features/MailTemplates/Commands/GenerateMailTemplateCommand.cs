using MediatR;
using OrganicDesignPatterns.Application.DesignPatterns.Factory;
using OrganicDesignPatterns.Application.DTOs.MailTemplates;
using OrganicDesignPatterns.Domain.Enums;

namespace OrganicDesignPatterns.Application.Features.MailTemplates.Commands;

public class GenerateMailTemplateCommand : IRequest<MailTemplateResultDto>
{
    public OrderStatus OrderStatus { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public string OrderNumber { get; set; } = string.Empty;

    public decimal TotalAmount { get; set; }
}

public class GenerateMailTemplateCommandHandler : IRequestHandler<GenerateMailTemplateCommand, MailTemplateResultDto>
{
    private readonly MailTemplateFactoryContext _mailTemplateFactoryContext;

    public GenerateMailTemplateCommandHandler(MailTemplateFactoryContext mailTemplateFactoryContext)
    {
        _mailTemplateFactoryContext = mailTemplateFactoryContext;
    }

    public Task<MailTemplateResultDto> Handle(
        GenerateMailTemplateCommand request,
        CancellationToken cancellationToken)
    {
        var mailTemplateRequest = new MailTemplateRequest
        {
            OrderStatus = request.OrderStatus,
            CustomerName = request.CustomerName,
            OrderNumber = request.OrderNumber,
            TotalAmount = request.TotalAmount
        };

        var template = _mailTemplateFactoryContext.CreateTemplate(request.OrderStatus);

        var result = new MailTemplateResultDto
        {
            OrderStatus = request.OrderStatus,
            TemplateName = template.TemplateName,
            Subject = template.GenerateSubject(mailTemplateRequest),
            Body = template.GenerateBody(mailTemplateRequest)
        };

        return Task.FromResult(result);
    }
}