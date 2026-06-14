using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrganicDesignPatterns.Application.Features.Discounts.Commands;

namespace OrganicDesignPatterns.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DiscountsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DiscountsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("calculate")]
    public async Task<IActionResult> CalculateDiscount(CalculateDiscountCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}