using MediatR;
using OrganicDesignPatterns.Application.DTOs.Products;
using OrganicDesignPatterns.Domain.Interfaces;

namespace OrganicDesignPatterns.Application.Features.Products.Queries;

public class GetProductByIdQuery : IRequest<ResultProductDto?>
{
    public int Id { get; set; }

    public GetProductByIdQuery(int id)
    {
        Id = id;
    }
}

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ResultProductDto?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProductByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.Id);

        if (product is null)
        {
            return null;
        }

        var category = await _unitOfWork.Categories.GetByIdAsync(product.CategoryId);

        return new ResultProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            DiscountedPrice = product.DiscountedPrice,
            Stock = product.Stock,
            ImageUrl = product.ImageUrl,
            IsFeatured = product.IsFeatured,
            IsActive = product.IsActive,
            CategoryId = product.CategoryId,
            CategoryName = category?.Name
        };
    }
}