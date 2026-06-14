using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrganicDesignPatterns.Application.Features.OrderValidation.Commands;

namespace OrganicDesignPatterns.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderValidationController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderValidationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("validate")]
    public async Task<IActionResult> ValidateOrder(ValidateOrderCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}