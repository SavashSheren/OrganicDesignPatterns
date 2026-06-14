using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrganicDesignPatterns.Application.Features.OrderEvents.Commands;

namespace OrganicDesignPatterns.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderEventsController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderEventsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("approve")]
    public async Task<IActionResult> ApproveOrder(ApproveOrderCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}