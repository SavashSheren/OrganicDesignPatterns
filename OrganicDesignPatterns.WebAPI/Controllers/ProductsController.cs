using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrganicDesignPatterns.Application.DTOs.Products;
using OrganicDesignPatterns.Application.Features.Products.Commands;
using OrganicDesignPatterns.Application.Features.Products.Queries;

namespace OrganicDesignPatterns.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _mediator.Send(new GetAllProductsQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var value = await _mediator.Send(new GetProductByIdQuery(id));

        if (value is null)
        {
            return NotFound("Product not found.");
        }

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto createProductDto)
    {
        try
        {
            var command = new CreateProductCommand
            {
                Name = createProductDto.Name,
                Description = createProductDto.Description,
                Price = createProductDto.Price,
                DiscountedPrice = createProductDto.DiscountedPrice,
                Stock = createProductDto.Stock,
                ImageUrl = createProductDto.ImageUrl,
                IsFeatured = createProductDto.IsFeatured,
                IsActive = createProductDto.IsActive,
                CategoryId = createProductDto.CategoryId
            };

            var createdId = await _mediator.Send(command);

            return Ok(new
            {
                Message = "Product created successfully.",
                Id = createdId
            });
        }
        catch (InvalidOperationException exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
    {
        try
        {
            var command = new UpdateProductCommand
            {
                Id = updateProductDto.Id,
                Name = updateProductDto.Name,
                Description = updateProductDto.Description,
                Price = updateProductDto.Price,
                DiscountedPrice = updateProductDto.DiscountedPrice,
                Stock = updateProductDto.Stock,
                ImageUrl = updateProductDto.ImageUrl,
                IsFeatured = updateProductDto.IsFeatured,
                IsActive = updateProductDto.IsActive,
                CategoryId = updateProductDto.CategoryId
            };

            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound("Product not found.");
            }

            return Ok("Product updated successfully.");
        }
        catch (InvalidOperationException exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new RemoveProductCommand(id));

        if (!result)
        {
            return NotFound("Product not found.");
        }

        return Ok("Product deleted successfully.");
    }
}