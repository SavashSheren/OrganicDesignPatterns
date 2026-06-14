using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrganicDesignPatterns.Application.Features.MailTemplates.Commands;

namespace OrganicDesignPatterns.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MailTemplatesController : ControllerBase
{
    private readonly IMediator _mediator;

    public MailTemplatesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("generate")]
    public async Task<IActionResult> GenerateMailTemplate(GenerateMailTemplateCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}