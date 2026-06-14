using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrganicDesignPatterns.Application.DTOs.Categories;
using OrganicDesignPatterns.Application.Features.Categories.Commands;
using OrganicDesignPatterns.Application.Features.Categories.Queries;

namespace OrganicDesignPatterns.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _mediator.Send(new GetAllCategoriesQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var value = await _mediator.Send(new GetCategoryByIdQuery(id));

        if (value is null)
        {
            return NotFound("Category not found.");
        }

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryDto createCategoryDto)
    {
        var command = new CreateCategoryCommand
        {
            Name = createCategoryDto.Name,
            Description = createCategoryDto.Description,
            ImageUrl = createCategoryDto.ImageUrl,
            IsActive = createCategoryDto.IsActive
        };

        var createdId = await _mediator.Send(command);

        return Ok(new
        {
            Message = "Category created successfully.",
            Id = createdId
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
    {
        var command = new UpdateCategoryCommand
        {
            Id = updateCategoryDto.Id,
            Name = updateCategoryDto.Name,
            Description = updateCategoryDto.Description,
            ImageUrl = updateCategoryDto.ImageUrl,
            IsActive = updateCategoryDto.IsActive
        };

        var result = await _mediator.Send(command);

        if (!result)
        {
            return NotFound("Category not found.");
        }

        return Ok("Category updated successfully.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new RemoveCategoryCommand(id));

        if (!result)
        {
            return NotFound("Category not found.");
        }

        return Ok("Category deleted successfully.");
    }
}