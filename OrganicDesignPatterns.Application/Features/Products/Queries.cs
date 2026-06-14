using MediatR;
using OrganicDesignPatterns.Application.DTOs.Products;
using OrganicDesignPatterns.Domain.Interfaces;

namespace OrganicDesignPatterns.Application.Features.Products.Queries;

public class GetAllProductsQuery : IRequest<List<ResultProductDto>>
{
}

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ResultProductDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllProductsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<ResultProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.Products.GetAllAsync();
        var result = new List<ResultProductDto>();

        foreach (var product in products)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(product.CategoryId);

            result.Add(new ResultProductDto
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
            });
        }

        return result;
    }
}