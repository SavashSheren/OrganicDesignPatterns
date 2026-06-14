using MediatR;
using OrganicDesignPatterns.Domain.Interfaces;

namespace OrganicDesignPatterns.Application.Features.Products.Commands;

public class UpdateProductCommand : IRequest<bool>
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public decimal? DiscountedPrice { get; set; }

    public int Stock { get; set; }

    public string? ImageUrl { get; set; }

    public bool IsFeatured { get; set; }

    public bool IsActive { get; set; }

    public int CategoryId { get; set; }
}

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.Id);

        if (product is null)
        {
            return false;
        }

        var category = await _unitOfWork.Categories.GetByIdAsync(request.CategoryId);

        if (category is null)
        {
            throw new InvalidOperationException("Category not found.");
        }

        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;
        product.DiscountedPrice = request.DiscountedPrice;
        product.Stock = request.Stock;
        product.ImageUrl = request.ImageUrl;
        product.IsFeatured = request.IsFeatured;
        product.IsActive = request.IsActive;
        product.CategoryId = request.CategoryId;

        _unitOfWork.Products.Update(product);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}