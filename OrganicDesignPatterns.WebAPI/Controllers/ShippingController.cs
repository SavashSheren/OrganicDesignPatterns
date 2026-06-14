using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrganicDesignPatterns.Application.Features.Shipping.Commands;

namespace OrganicDesignPatterns.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShippingController : ControllerBase
{
    private readonly IMediator _mediator;

    public ShippingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("calculate")]
    public async Task<IActionResult> CalculateShipping(CalculateShippingCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}